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
                    query = @"select iphone_id,iphone_name,iphone_process,iphone_memory,color_name,iphone_storage,iphone_camera,iphone_battery,iphone_screen,iphone_wireless_network,iphone_waterproof,iphone_support,iphone_price,amount from iphones,colors where iphones.color_id = colors.color_id and iphone_id = @iphoneId order by iphone_id;";
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
            iphone.IphoneColor = reader.GetString("color_name");
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
            iphone.Amount = reader.GetInt32("amount");
            return iphone;
        }
        // public Iphone GetMoreIphone(MySqlDataReader reader)
        // {
        //     Iphone iphone = new Iphone();
        //     iphone.IphoneID = reader.GetInt32("iphone_id");
        //     iphone.IphoneName = reader.GetString("iphone_name");
        //     iphone.IphoneMemory = reader.GetString("iphone_memory");
        //     iphone.IphoneStorage = reader.GetString("iphone_storage");
        //     iphone.IphonePrice = reader.GetDouble("iphone_price");
        //     Console.WriteLine("| {0,-2} | {1,-20} | {2,-10} | {3,-10} | {4,-10} |",iphone.IphoneID,iphone.IphoneName,iphone.IphoneMemory,iphone.IphoneStorage,iphone.IphonePrice);
        //     return iphone;
        // }
        
        public List<Iphone> GetAllIphone()
        {
            List<Iphone> lst = null;
            lock (connection)
            {
                connection.Open();
                string scommand = "select iphone_id,iphones.iphone_name,colors.color_name,iphones.iphone_memory,iphones.iphone_storage,iphones.iphone_price from iphones,colors where iphones.color_id = colors.color_id order by iphones.iphone_id;";
                MySqlCommand command = new MySqlCommand(scommand,connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    Console.WriteLine("|                                  IPHONE STORE                                   |");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    Console.WriteLine("| ID | Name                 | Color        | Memory     | Storage    | Price      |");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    while(reader.Read())
                    {
                        string id = reader["iphone_id"].ToString();
                        string name = reader["iphone_name"].ToString();
                        string color = reader["color_name"].ToString();
                        string memory = reader["iphone_memory"].ToString();
                        string storage = reader["iphone_storage"].ToString();
                        string price = reader["iphone_price"].ToString();
                        Console.WriteLine("| {0,-2} | {1,-20} | {2,-12} | {3,-10} | {4,-10} | {5,-10} |",id,name,color,memory,storage,price);
                    }
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    reader.Close();
                }
                connection.Close();
            }
            return lst;
            
        }
        public List<Iphone> GetIphoneByName(string iphoneName)
        {
            List<Iphone> lst = null;
            lock (connection)
            {
                connection.Open();
                string scommand = @"select iphone_id,iphones.iphone_name,colors.color_name,iphones.iphone_memory,iphones.iphone_storage,iphones.iphone_price from iphones,colors where iphones.color_id = colors.color_id and iphone_name like concat('%',@iphoneName,'%');";
                MySqlCommand command = new MySqlCommand(scommand,connection);
                command.Parameters.AddWithValue("@iphoneName",iphoneName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    Console.WriteLine("|                                  IPHONE STORE                                   |");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    Console.WriteLine("| ID | Name                 | Color        | Memory     | Storage    | Price      |");
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    while(reader.Read())
                    {
                        string id = reader["iphone_id"].ToString();
                        string name = reader["iphone_name"].ToString();
                        string color = reader["color_name"].ToString();
                        string memory = reader["iphone_memory"].ToString();
                        string storage = reader["iphone_storage"].ToString();
                        string price = reader["iphone_price"].ToString();
                        Console.WriteLine("| {0,-2} | {1,-20} | {2,-12} | {3,-10} | {4,-10} | {5,-10} |",id,name,color,memory,storage,price);
                    }
                    Console.WriteLine("+---------------------------------------------------------------------------------+");
                    reader.Close();
                }
                connection.Close();
            }
            return lst;
        }
        // public Iphone GetIphoneByName(string iphoneName)
        // {
            
        //     Iphone iphone = null;
        //     lock (connection)
        //     {
        //         try
        //         {
        //             connection.Open();
        //             query = @"iphone_id,iphones.iphone_name,colors.color_name,iphones.iphone_memory,iphones.iphone_storage,iphones.iphone_price from iphones,colors where iphones.color_id = colors.color_id and iphone_name= @iphoneName;";
        //             MySqlCommand command = new MySqlCommand(query, connection);
        //             command.Parameters.AddWithValue("@iphoneName", iphoneName);
        //             MySqlDataReader reader = command.ExecuteReader();
        //             Console.WriteLine("+---------------------------------------------------------------------------------+");
        //             Console.WriteLine("|                                  IPHONE STORE                                   |");
        //             Console.WriteLine("+---------------------------------------------------------------------------------+");
        //             Console.WriteLine("| ID | Name                 | Color        | Memory     | Storage    | Price      |");
        //             Console.WriteLine("+---------------------------------------------------------------------------------+");
        //             if(reader.Read())
        //             {
        //                 string id = reader["iphone_id"].ToString();
        //                 string name = reader["iphone_name"].ToString();
        //                 string color = reader["color_name"].ToString();
        //                 string memory = reader["iphone_memory"].ToString();
        //                 string storage = reader["iphone_storage"].ToString();
        //                 string price = reader["iphone_price"].ToString();
        //                 Console.WriteLine("| {0,-2} | {1,-20} | {2,-12} | {3,-10} | {4,-10} | {5,-10} |",id,name,color,memory,storage,price);
        //             }
        //             reader.Close();
        //         }
        //         catch { }
        //         finally{connection.Close();}
        //     }
        //     return iphone;
        // }
    }
}