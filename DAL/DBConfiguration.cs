using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBConfiguration
    {
        private static MySqlConnection connection;
        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                using (System.IO.FileStream fileStream = System.IO.File.OpenRead("Iphonestore.txt"))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                    {
                        connection = new MySqlConnection
                        {
                            ConnectionString = reader.ReadLine()
                        };
                    }
                }
            }
            return connection;
        }
    // private DbHelper(){}
}
}
