using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace TFOIBeta.Classes
{
    public class Database
    {
        static SQLiteConnection connection = new SQLiteConnection("Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "resources\\isaac.db");
        static SQLiteCommand command = null;
        static SQLiteDataReader reader = null;
        static SQLiteTransaction transaction;
        public static DataTable dataTable = new DataTable();

        public static void SubmitRun(string seed, string timestamp, string charName, string itemIdList, string bossList, string time, string result)
        {
            string query = "INSERT INTO runs (Seed, Timestamp, CharName, Items, Bosses, Time, Result) VALUES";
            query += "(@seed, @dateTime, @character, @itemIdList, @bossList, @result)";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Seed", seed);
            command.Parameters.AddWithValue("@Timestamp", timestamp);
            command.Parameters.AddWithValue("@CharName", charName);
            command.Parameters.AddWithValue("@Items", itemIdList);
            command.Parameters.AddWithValue("@Bosses", bossList);
            command.Parameters.AddWithValue("@Time", time);
            command.Parameters.AddWithValue("@Result", result);

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


    }
}
