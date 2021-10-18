using System;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class CustomerDAL
    {
        private string query;
        private MySqlConnection connection = DBConfiguration.GetConnection();
        private MySqlDataReader reader;

        public CustomerDAL()
        {
            
        }
        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            try
            {
                connection.Open();
                query = @"select * from customers where customer_id =" + customerId + ";";
                reader = (new MySqlCommand(query, connection)).ExecuteReader();
                if(reader.Read())
                {
                    customer = GetCustomer(reader);
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return customer;
        }
        internal Customer GetCustomer(MySqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = reader.GetInt32("customer_id");
            customer.CustomerName = reader.GetString("customer_name");
            customer.CustomerAddress = reader.GetString("customer_address");
            customer.CustomerEmail = reader.GetString("customer_email");
            customer.CustomerPhone = reader.GetString("customer_phone");
            return customer;
        }
        public int? AddCustomer(Customer customer)
        {
            int? result = null;
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand("sp_createCustomer",connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@customerName", customer.CustomerName);
                command.Parameters["@customerName"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@customerAddress", customer.CustomerAddress);
                command.Parameters["@customerAddress"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@customerEmail", customer.CustomerEmail);
                command.Parameters["@customerEmail"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@customerPhone", customer.CustomerPhone);
                command.Parameters["@customerPhone"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@customerId", MySqlDbType.Int32);
                command.Parameters["@customerId"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                result = (int)command.Parameters["@customerId"].Value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public Customer DeleteCustomerByID(int customerid)
        {
            Customer customer = null;
            try
            {
                connection.Open();
                query = @"DELETE FROM customers WHERE customer_id = " + customerid + ";";
                reader = (new MySqlCommand(query, connection)).ExecuteReader();
                Console.WriteLine("Delete Complete!");
                reader.Close();
            }
            catch {}
            return customer;
        }
    }
}