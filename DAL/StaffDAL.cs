using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class StaffDAL
    {
        private MySqlConnection connection = DBConfiguration.GetConnection();
        public Staff Login(Staff staff)
        {
            lock (connection)
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "select * from Staffs where user_name=@userName and user_pass=@userPass;";
                    command.Parameters.AddWithValue("@userName", staff.UserName);
                    command.Parameters.AddWithValue("@userPass", Md5Algorithms.CreateMD5(staff.Password));
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        staff.Role = reader.GetInt32("role");
                    }
                    else
                    {
                        staff.Role = 0;
                    }
                    reader.Close();
                }
                catch
                {
                    staff.Role = -1;
                }
                finally
                {
                    connection.Close();
                }
            }
            return staff;
        }

        public int Insert(Staff staff)
        {
            int? result = null;
            MySqlConnection connection = DBConfiguration.GetConnection();
            string sql = @"insert into Staffs(staff_name, user_name, user_pass, role) values 
                      (@staffName, @userName, @userPass, @role);";
            lock (connection)
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@staffName", staff.StaffName);
                    command.Parameters.AddWithValue("@userName", staff.UserName);
                    command.Parameters.AddWithValue("@userPass", staff.Password);
                    command.Parameters.AddWithValue("@role", staff.Role);
                    result = command.ExecuteNonQuery();
                }
                catch
                {
                    result = -2;
                }
                finally
                {
                    connection.Close();
                }
            }
            return result ?? 0;
        }

        public List<Staff> GetAll()
        {
            return null;
        }
        public Staff ShowProfile(Staff staff)
        {
            lock(connection)
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("select * from Staffs where user_name= 'sale' and user_pass ='a288c42085685d673b9450d539e06695';",connection);
                    
                    MySqlDataReader reader = command.ExecuteReader();
                    string id = reader["staff_id"].ToString();
                    string name = reader["staff_name"].ToString();
                    string phone = reader["telephone"].ToString();
                    string email = reader["email"].ToString();
                    string role = reader["role"].ToString();
                    if (reader.Read())
                    {
                        staff.Role = reader.GetInt32("role");
                    }
                    else
                    {
                        staff.Role = 0;
                    }
                    reader.Close();
                }
                catch
                {
                    staff.Role = -1;
                }
                finally
                {
                    connection.Close();
                }
            }
            return staff;
        }
    }
}