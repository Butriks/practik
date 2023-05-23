using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace practik
{
    class ProfilesTable
    {
        private readonly DB db;

        public ProfilesTable(DB db) => this.db = db;

        public ProfilesTable(string server, int port, string username, string password, string database)
        {
            db = new DB(server, port, username, password, database);
        }

        public bool CheckExistUser(int userId)
        {
            string query = $"SELECT COUNT(*) FROM profiles WHERE user_id = {userId}";
            int count = Convert.ToInt32(db.ExecuteScalar(query));
            if (count == 0)
            {
                return false;
            }
            else { return true; }
        }
        public void SetFirstName(int userId, string firstName)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, first_name) VALUES ({userId}, '{firstName}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET first_name = '{firstName}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetLastName(int userId, string lastName)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, last_name) VALUES ({userId}, '{lastName}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET last_name = '{lastName}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetPatronymic(int userId, string patronymic)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, patronymic) VALUES ({userId}, '{patronymic}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET patronymic = '{patronymic}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetLocation(int userId, string location)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, location) VALUES ({userId}, '{location}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET location = '{location}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetAge(int userId, int age)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, age) VALUES ({userId}, '{age}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET age = '{age}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public void SetInterests(int userId, string interests)
        {
            string query;
            if (!CheckExistUser(userId))
            {
                query = $"INSERT INTO profiles (user_id, interests) VALUES ({userId}, '{interests}')";
                db.ExecuteNonQuery(query);
            }
            else
            {
                query = $"UPDATE profiles SET interests = '{interests}' WHERE user_id = {userId}";
                db.ExecuteNonQuery(query);
            }
        }

        public string GetFirstName(int userId)
        {
            string query = $"SELECT first_name FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string firstName = string.Empty;
            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("first_name")))
                {
                    firstName = reader.GetString("first_name");
                }
            }
            DB.CloseDataReader(reader);
            return firstName;
        }

        public string GetLastName(int userId)
        {
            string query = $"SELECT last_name FROM profiles WHERE user_id ={userId}";
            MySqlDataReader reader = db.ExecuteReader(query);
            string lastName = string.Empty;
            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("last_name")))
                {
                    lastName = reader.GetString("last_name");
                }
            }
            DB.CloseDataReader(reader);
            return lastName;
        }

    }
}