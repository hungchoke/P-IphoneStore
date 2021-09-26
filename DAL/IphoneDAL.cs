using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public static class IphoneFilter
    {
        public const int GET_ALL = 0;
        public const int FILTER_BY_ITEM_NAME = 1;
    }
    public class IphoneDAL
    {
        private string query;
        private MySqlConnection connection = DBConfiguration.GetConnection();

        public Iphone GetIphoneById(int iphoneId)
        {
            Iphone iphone = null;
            lock (connection)
            {
                try
                {
                    connection.Open();
                    query = @"select * from iphones where iphone_id= @iphoneId;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@iphoneId", iphoneId);
                    MySqlDataReader reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        iphone = GetIphone(reader);
                    }
                    reader.Close();
                }
                catch { }
                finally{connection.Close();}
            }
            return iphone;
        }

        public Iphone GetIphone(MySqlDataReader reader)
        {
            Iphone iphone = new Iphone();
            iphone.IphoneID = reader.GetInt32("iphone_id");
            iphone.IphoneName = reader.GetString("iphone_name");
            iphone.IphoneColor = reader.GetInt32("color_id");
            iphone.IphoneScreen = reader.GetString("iphone_screen");
            iphone.IphoneProcess = reader.GetString("iphone_process");
            iphone.IphoneStorage = reader.GetString("iphone_storage");
            iphone.IphoneCamera = reader.GetString("iphone_camera");
            iphone.IphoneBattery = reader.GetString("iphone_battery");
            iphone.IphoneWirelessNetwork = reader.GetString("iphone_wireless_network");
            iphone.IphoneSupport = reader.GetString("iphone_support");
            iphone.IphoneWaterproof = reader.GetString("iphone_waterproof");
            iphone.IphoneMemory = reader.GetString("iphone_memory");
            iphone.IphoneStorage = reader.GetString("iphone_storage");
            iphone.IphonePrice = reader.GetDouble("iphone_price");
            return iphone;
        }
        public Iphone GetMoreIphone(MySqlDataReader reader)
        {
            Iphone iphone = new Iphone();
            iphone.IphoneID = reader.GetInt32("iphone_id");
            iphone.IphoneName = reader.GetString("iphone_name");
            iphone.IphoneMemory = reader.GetString("iphone_memory");
            iphone.IphoneStorage = reader.GetString("iphone_storage");
            iphone.IphonePrice = reader.GetDouble("iphone_price");
            Console.WriteLine("| {0,-2} | {1,-20} | {2,-10} | {3,-10} | {4,-10} |",iphone.IphoneID,iphone.IphoneName,iphone.IphoneMemory,iphone.IphoneStorage,iphone.IphonePrice);
            return iphone;
        }
        public List<Iphone> GetIphones(int iphoneFilter,Iphone iphone)
        {
            List<Iphone> lst = null;
            lock (connection)
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("",connection);
                    switch(iphoneFilter)
                    {
                        case IphoneFilter.GET_ALL:
                            query = @"select * from Iphones";
                            break;
                        case IphoneFilter.FILTER_BY_ITEM_NAME:
                            query = @"select iphone_id,iphone_name,color_id,iphone_memory,iphone_storage,iphone_price from Iphones
                                                where iphone_name like concat('%',@iphoneName,'%');";  
                            command.Parameters.AddWithValue("@iphoneName",iphone.IphoneName);
                            break; 
                    }
                    command.CommandText = query;
                    MySqlDataReader reader = command.ExecuteReader();
                    lst = new List<Iphone>();
                    while (reader.Read())
                    {
                        lst.Add(GetMoreIphone(reader));
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lst;
        }
        public List<Iphone> GetAllIphone()
        {
            List<Iphone> lst = null;
            lock (connection)
            {
                connection.Open();
                string scommand = "SELECT * FROM iphones";
                MySqlCommand command = new MySqlCommand(scommand,connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("|                           IPHONE STORE                           |");
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("| ID | Name                 | Memory     | Storage    | Price      |");
                    Console.WriteLine("+------------------------------------------------------------------+");
                    while(reader.Read())
                    {
                        string id = reader["iphone_id"].ToString();
                        string name = reader["iphone_name"].ToString();
                        string memory = reader["iphone_memory"].ToString();
                        string storage = reader["iphone_storage"].ToString();
                        string price = reader["iphone_price"].ToString();
                        Console.WriteLine("| {0,-2} | {1,-20} | {2,-10} | {3,-10} | {4,-10} |",id,name,memory,storage,price);
                    }
                    Console.WriteLine("+------------------------------------------------------------------+");
                    reader.Close();
                }
                connection.Close();
            }
            return lst;
            
        }
        public List<Iphone> GetIphoneByName()
        {
            List<Iphone> lst = null;
            lock (connection)
            {
                connection.Open();
                string scommand = @"select iphone_id,iphone_name,iphone_memory,iphone_storage,iphone_price from Iphones where iphone_name like concat('%',@iphoneName,'%');";
                MySqlCommand command = new MySqlCommand(scommand,connection);
                Console.WriteLine("Input iphone id: ");
                string iphoneName = Console.ReadLine();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("|                           IPHONE STORE                           |");
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("| ID | Name                 | Memory     | Storage    | Price      |");
                    Console.WriteLine("+------------------------------------------------------------------+");
                    while(reader.Read())
                    {
                        string id = reader["iphone_id"].ToString();
                        string name = reader["iphone_name"].ToString();
                        string memory = reader["iphone_memory"].ToString();
                        string storage = reader["iphone_storage"].ToString();
                        string price = reader["iphone_price"].ToString();
                        Console.WriteLine("| {0,-2} | {1,-20} | {2,-10} | {3,-10} | {4,-10} |",id,name,memory,storage,price);
                    }
                    Console.WriteLine("+------------------------------------------------------------------+");
                    reader.Close();
                }
                connection.Close();
            }
            return lst;
        }
    }
}