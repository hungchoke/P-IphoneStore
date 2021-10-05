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
            Console.WriteLine("Name: ");
            string _name = Console.ReadLine();
            Console.WriteLine("Address: ");
            string _address = Console.ReadLine();
            Console.WriteLine("Email: ");
            string _email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            string _phone = Console.ReadLine();
            int? result = null;
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand("insert into customers values (@customer_id,@customer_name,@customer_address,customer_email,customer_phone)",connection);
            try
            {
                command.Parameters.AddWithValue("@customer_name",_name);
                command.Parameters.AddWithValue("@customer_address",_address);
                command.Parameters.AddWithValue("@customer_email",_email);
                command.Parameters.AddWithValue("@customer_phone",_phone);
                command.Parameters.AddWithValue("@customer_id",MySqlDbType.Int32);
                command.ExecuteNonQuery();
                result = (int)command.Parameters["@customer_id"].Value;
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
    }
}