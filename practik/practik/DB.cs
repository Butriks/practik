
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;



namespace practik
{
    using MySql.Data.MySqlClient;
    using System;

    class DB
    {
        private readonly string connectionString;
        private MySqlConnection connection;

        public DB(string server, int port, string username, string password, string database)
        {
            connectionString = $"server={server};port={port};username={username};password={password};database={database}";
        }

        public void OpenConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public MySqlDataReader ExecuteReader(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
                return null;
            }
        }


        public object ExecuteScalar(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }

        }
        static public void CloseDataReader(MySqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }
        }

    }

}
