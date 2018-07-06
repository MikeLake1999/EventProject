using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class UserDB
    {
        private string query;
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public UserDB()
        {
            connection = DbConfiguration.OpenConnection();
        }

        public User Login(string username, string password)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count <= 0 || matchCollectionPassword.Count <= 0)
            {
                return null;
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = @"select * from UserDB where user_name = '" + username + "' and user_password= '" + password + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            User user = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = GetUser(reader);
                }
            }

            connection.Close();

            return user;
        }
        private User GetUser(MySqlDataReader reader)
        {
           User user = new User();
           user.Name = reader.GetString("name_user");
           user.Age = reader.GetInt32("age");
           user.Address = reader.GetString("address");
           user.Email = reader.GetString("Email");
           user.Phone = reader.GetInt32("phone_number");
           user.AccountType = reader.GetString("type_account");
           user.User_Name = reader.GetString("user_name");
           user.Password = reader.GetString("user_password");

            return user;

            

        }


        
    }

}
