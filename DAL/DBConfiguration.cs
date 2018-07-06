﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;

namespace DAL
{
    public class DbConfiguration
    {
        private static string CONNECTION_STRING = "server=localhost;user id=EventUser;password=123456789;port=3306;database=userdb;SslMode=None";
        private static string conString = null;
        public static MySqlConnection OpenDefaultConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = CONNECTION_STRING
                };
                connection.Open();
                return connection;
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection OpenConnection()
        {
            try
            {
                if (conString == null)
                {
                    using (FileStream fileStream = File.OpenRead("ConnectionString.txt"))
                    {
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            conString = reader.ReadLine();
                        }
                    }
                }
                return OpenConnection(conString);
            }
            catch
            {
                return null;
            }
        }

        public static MySqlConnection OpenConnection(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }
            catch
            {
                return null;
            }
        }
    }
}