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
        static SQLiteDataReader reader = null;
        static SQLiteTransaction transaction;
        public static DataTable dataTable = new DataTable();

        public static void SubmitRun(string seed, string timestamp, string charName, string itemIdList, string bossList, string killedBy, string time, string result)
        {
            string query = "INSERT INTO runs(Seed, TimeStamp, CharName, Items, Bosses, KilledBy, Time, Result) VALUES";
            query += "(@seed, @timestamp, @charName, @itemIdList, @bossList, @killedBy,@time,  @result)";

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@seed", seed);
            command.Parameters.AddWithValue("@timestamp", timestamp);
            command.Parameters.AddWithValue("@charName", charName);
            command.Parameters.AddWithValue("@itemIdList", itemIdList);
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


    }
}
