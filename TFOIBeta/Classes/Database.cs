﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;

namespace TFOIBeta.Classes
{
    public class Database
    {
        static SQLiteConnection connection = new SQLiteConnection("Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "resources\\isaac.db");
        static SQLiteCommand command;
        static SQLiteDataReader reader = null;
        static SQLiteDataAdapter dataAdapter;
        static SQLiteTransaction transaction;
        public static DataTable dataTable = new DataTable();

        public static bool CheckIfColumnExists(string tableName, string columnName)
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
            if (!CheckIfColumnExists("runs", "Floors"))
            {
                try
                {
                    connection.Open();
                    command.CommandText = "ALTER TABLE runs ADD COLUMN Floors TEXT;";
                    command.ExecuteNonQuery();
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
            }
        }

        public static void SubmitRun(string seed, string timestamp, string charName, string itemIdList, string floorList, string bossList, string killedBy, string time, string result)
        {
            string query = "INSERT INTO runs(Seed, TimeStamp, CharName, Items, Floors, Bosses, KilledBy, Time, Result) VALUES";
            query += "(@seed, @timestamp, @charName, @itemIdList, @floorList, @bossList, @killedBy,@time,  @result)";

            SQLiteCommand command = new SQLiteCommand(query, connection);
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

        public static void SelectAll(DataGrid dg)
        {
            string query = "SELECT * FROM 'runs'";

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataAdapter.Fill(dataTable);

                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void SelectItem(DataGrid dg, string ItemID)
        {
            string query = "SELECT * FROM 'runs' WHERE Items = " + ItemID;

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

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
            string query = "SELECT * FROM 'runs' WHERE CharName = " + CharName;

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataAdapter.Fill(dataTable);

                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
        public static void SelectBoss(DataGrid dg, string BossID)
        {
            string query = "SELECT * FROM 'runs' WHERE Items = " + BossID;

            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                dataAdapter = new SQLiteDataAdapter(command);

                dataAdapter.Fill(dataTable);

                dg.ItemsSource = dataTable.DefaultView;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

    }
}
