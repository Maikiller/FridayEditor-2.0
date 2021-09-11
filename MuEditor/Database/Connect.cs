using MuEditor.Forms.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace MuEditor.Database
{
    internal class Connect
    {
        private static MySqlConnection con;

        public static MySqlConnection Connection()
        {

            con = new(
                       "" +
                       "Server=" + Config.server + ";" +
                       "Port=" + Config.port + ";" +
                       "Database=" + Config.database + ";" +
                       "Uid=" + Config.user + ";" +
                       "Pwd=" + Config.password + ";" +
                       "Connection Timeout=5;"
                       );
            return con;
        }

        public static void DetectedApplicationError()
        {
            MessageBoxCustomError boxError = new();
            try
            {
                Connection().Open();
                Config.applicationError = 0;
            }
            catch (Exception ex)
            {
                Config.applicationError = 1;

                boxError.CustomMessage.Text = ex.Message;
                boxError.ShowDialog();
            }
            Connection().ClearAllPoolsAsync();
            return;
        }
        public static DataTable LoadData(string sql)
        {
            DataTable data = new();
            MySqlDataAdapter da;
            var cmd = Connection().CreateCommand();
            cmd.CommandText = sql;
            da = new MySqlDataAdapter(cmd.CommandText, Connection());
            try
            {
                da.Fill(data);
            }
            catch (MySqlException ex)
            {
                MessageBoxCustomError box = new();
                box.CustomMessage.Text = ex.Message;
                box.ShowDialog();
            }
            return data;
        }

        public static void Update(string sql)
        {
            var cmd = Connection().CreateCommand();
            cmd.CommandText = sql;
            con.Open();
            try
            {
                cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBoxCustomError box = new();
                box.CustomMessage.Text = ex.Message;
                box.ShowDialog();
            }
            con.Close();
        }
    }
}