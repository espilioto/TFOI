using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Globalization;
using System.IO;
using System.Windows;

namespace TFOI
{
    public class Database
    {
        public static List<ArchivedRun> ArchivedRuns = new List<ArchivedRun>();
        static ArchivedRun archivedRun;

        static SQLiteConnection connection = new SQLiteConnection("Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + @"resources\isaac.db");
        static SQLiteCommand command;
        static SQLiteDataReader reader = null;
        static SQLiteDataAdapter dataAdapter;
        static SQLiteTransaction transaction;
        public static DataTable dataTable = new DataTable();
        public static DataTable dataTable2 = new DataTable();

        public static void Backup()
        {
            if (Properties.Settings.Default.backupEnabled)
            {
                try
                {
                    File.Copy(System.AppDomain.CurrentDomain.BaseDirectory + @"resources\isaac.db", Properties.Settings.Default.backupPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.Data);
                }
            }
        }

        private static bool DatabaseFileExists()
        {
            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"resources\isaac.db"))
                return true;
            else
                return false;
        }
        public static void CreateDatabaseFile()
        {
            string query = "CREATE TABLE [runs] ([Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [Seed] text, [Timestamp] text, [CharName] text, [Items] text, [Bosses] text, [KilledBy] text, [Time] text, [Result] text, [Floors] text)";
            if (!DatabaseFileExists())
            {
                try
                {
                    SQLiteConnection.CreateFile(System.AppDomain.CurrentDomain.BaseDirectory + @"resources\isaac.db");

                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    transaction.Rollback();
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
        }

        private static bool CheckIfColumnExists(string tableName, string columnName)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = string.Format("PRAGMA table_info({0})", tableName);

            reader = command.ExecuteReader();
            int nameIndex = reader.GetOrdinal("Name");
            while (reader.Read())
            {
                if (reader.GetString(nameIndex).Equals(columnName))
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    connection.Close();
                    return true;
                }
            }
            if (reader != null)
            {
                reader.Close();
            }
            connection.Close();
            return false;
        }
        public static void CreateFloorsColumn()
        {
            string query = "ALTER TABLE runs ADD COLUMN Floors TEXT;";
            try
            {
                if (!CheckIfColumnExists("runs", "Floors"))
                {
                    command = new SQLiteCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public static void SubmitRun(string seed, string timestamp, string charName, string itemIdList, string bossList, string killedBy, string time, string result, string floorList)
        {
            string query = "INSERT INTO runs(Seed, TimeStamp, CharName, Items, Floors, Bosses, KilledBy, Time, Result) VALUES";
            query += "(@seed, @timestamp, @charName, @itemIdList, @floorList, @bossList, @killedBy,@time,  @result)";

            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@seed", seed);
            command.Parameters.AddWithValue("@timestamp", timestamp);
            command.Parameters.AddWithValue("@charName", charName);
            command.Parameters.AddWithValue("@itemIdList", itemIdList);
            command.Parameters.AddWithValue("@floorList", floorList);
            command.Parameters.AddWithValue("@bossList", bossList);
            command.Parameters.AddWithValue("@killedBy", killedBy);
            command.Parameters.AddWithValue("@time", time);
            command.Parameters.AddWithValue("@result", result);

            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Commit();
                command.Dispose();
                connection.Close();
            }
        }

        /// <summary>
        /// This query fills Database.datatable2. Use it to calculate global run stats etc.  
        /// </summary>
        public static void SelectAll()
        {
            string query = "SELECT * FROM runs";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataTable2.Clear();
                dataAdapter.Fill(dataTable2);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void SelectAll(DataGrid dg)
        {
            string query = "SELECT * FROM runs";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void DeserializeRunsFromDB()
        {
            string items = string.Empty, floors = string.Empty, bosses = string.Empty;

            foreach (DataRow row in dataTable.Rows)
            {
                archivedRun = new ArchivedRun();

                archivedRun.Id = row.ItemArray[0].ToString();
                archivedRun.Seed = row.ItemArray[1].ToString();
                archivedRun.Timestamp = row.ItemArray[2].ToString();
                archivedRun.Character = Characters.GetCharFromName(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(row.ItemArray[3].ToString().ToLower()));
                items = row.ItemArray[4].ToString();
                bosses = row.ItemArray[5].ToString();
                archivedRun.KilledBy = Bosses.GetBossFromId(row.ItemArray[6].ToString());
                archivedRun.Time = row.ItemArray[7].ToString();
                archivedRun.Result = row.ItemArray[8].ToString();
                floors = row.ItemArray[9].ToString();

                foreach (string item in items.Split(','))
                {
                    archivedRun.Items.Add(Items.GetItemFromId(item));
                }
                foreach (string boss in bosses.Split(','))
                {
                    archivedRun.Bosses.Add(Bosses.GetBossFromId(boss));
                }
                foreach (string floor in floors.Split(','))
                {
                    archivedRun.Floors.Add(Floors.GetFloorFromId(floor));
                }

                ArchivedRuns.Add(archivedRun);
            }
        }
        public static void SelectItem(DataGrid dg, string ItemId)
        {
            string query = "SELECT * FROM runs WHERE instr(Items, '" + ItemId + "')";

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", ItemId);
                dataAdapter = new SQLiteDataAdapter(command);

                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void SelectChar(DataGrid dg, string CharName)
        {
            string query = "SELECT * FROM runs WHERE CharName = @CharName";

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CharName", CharName);
                dataAdapter = new SQLiteDataAdapter(command);

                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void SelectBoss(DataGrid dg, string BossId)
        {
            string query = "SELECT * FROM runs WHERE instr(Bosses, '" + BossId + "')";

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public static void DeleteRun(string id)
        {
            string query = "DELETE FROM runs WHERE Id = @id";

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                dataAdapter = new SQLiteDataAdapter(command);
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
    }
}
