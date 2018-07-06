using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class EventDAL
    {
        private string query;
        private MySqlConnection connection = DbConfiguration.OpenConnection();
        private MySqlDataReader reader;
        public Event GetById(int eventId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select event_id, event_name,
                        ifnull(event_address, '') as event_address
                        from Events where event_id=" + eventId + ";";
            reader = (new MySqlCommand(query, connection)).ExecuteReader();
            Event c = null;
            if (reader.Read())
            {
                c = GetEvent(reader);
            }
            reader.Close();
            connection.Close();
            return c;
        }

        internal Event GetById(int eventId, MySqlConnection connection)
        {
            query = @"select event_id, event_name, address, time
                        ifnull(description, '') as description
                        from EventDB where event_id=" + eventId + ";";
            Event c = null;
            reader = (new MySqlCommand(query, connection)).ExecuteReader();
            if (reader.Read())
            {
                c = GetEvent(reader);
            }
            reader.Close();
            return c;
        }
        private Event GetEvent(MySqlDataReader reader)
        {
            Event c = new Event();
            c.ID_Event = reader.GetString("event_id");
            c.Name_Event = reader.GetString("event_name");
            c.Description = reader.GetString("description");
            c.Address_Event = reader.GetString("address");
            c.Time = reader.GetDateTime("time");
            return c;
        }

        public int? AddEvent(Event c)
        {
            int? result = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand cmd = new MySqlCommand("sp_createEvent", connection);
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@time", c.Time);
                cmd.Parameters["@time"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@event_name", c.Name_Event);
                cmd.Parameters["@event_name"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@address", c.Address_Event);
                cmd.Parameters["@address"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@event_id", c.ID_Event);
                cmd.Parameters["@event_id"].Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@event_id"].Value;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}