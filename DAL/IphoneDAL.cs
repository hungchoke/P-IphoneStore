using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public static class IphoneFilter
    {
        public const int GET_ALL = 0;
        public const int FILTER_BY_ITEM_COLOR = 1;
    }
    public class IphoneDAL
    {
        private string query;
        private MySqlConnection connection = DbHelper.GetConnection();

        public Iphone GetIphoneById(int iphoneId)
        {
            Iphone iphone = null;
            try
            {
                connection.Open();
                query = @"select iphone_id,iphone_name,iphone_price from Iphones where iphone_id=@itemId;";
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
            return iphone;
        }
        private Iphone GetIphone(MySqlDataReader reader)
        {
            Iphone iphone = new Iphone();
            iphone.IphoneID = reader.GetInt32("iphone_id");
            iphone.IphoneName = reader.GetString("iphone_name");
            iphone.IphoneColor = reader.GetString("iphone_color");
            iphone.IphoneMemory = reader.GetString("iphone_memory");
            iphone.IphoneStorage = reader.GetString("iphone_storage");
            iphone.IphonePrice = reader.GetDouble("iphone_price");
            return iphone;
        }
        public List<Iphone> GetIphones(int iphoneFilter,Iphone iphone)
        {
            List<Iphone> lst = null;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("",connection);
                switch(iphoneFilter)
                {
                    case IphoneFilter.GET_ALL:
                        query = @"select iphone_id,iphone_name,iphone_color,iphone_memory,iphone_storage,iphone_price from Iphones";
                        break;
                    case IphoneFilter.FILTER_BY_ITEM_COLOR:
                        query = @"select iphone_id,iphone_name,iphone_color,iphone_memory,iphone_storage,iphone_price from Iphones
                                            where item_color like concat('%',@iphoneName,'%');";  
                        command.Parameters.AddWithValue("@iphoneName",iphone.IphoneName);
                        break;                      
                }
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                lst = new List<Iphone>();
                while (reader.Read())
                {
                    lst.Add(GetIphone(reader));
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
            return lst;
        }
    }
}