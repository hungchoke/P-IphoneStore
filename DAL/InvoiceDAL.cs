using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public class InvoiceDAL
    {
        private string query;
        private MySqlConnection connection = DBConfiguration.GetConnection();
        public bool CreateInvoice(Invoice invoice)
        {
            if(invoice  ==null || invoice.IphoneList == null || invoice.IphoneList.Count == 0)
            {
                return false;
            }
            bool result = true;
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                //lock update all table
                command.CommandText = "lock tables Customers write,Invoices write,Iphones write,InvoiceDetailts write;";
                command.ExecuteNonQuery();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                MySqlDataReader reader = null;
                if(invoice.OrderCustomer == null || invoice.OrderCustomer.CustomerName == null || invoice.OrderCustomer.CustomerName == "")
                {
                    invoice.OrderCustomer = new Customer(){CustomerId = 1};
                }
                try
                {
                    //Insert Customer
                    command = new MySqlCommand("sp_createCustomer",connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@customerName", invoice.OrderCustomer.CustomerName);
                    command.Parameters["@customerName"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@customerAddress", invoice.OrderCustomer.CustomerAddress);
                    command.Parameters["@customerAddress"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@customerEmail", invoice.OrderCustomer.CustomerEmail);
                    command.Parameters["@customerEmail"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@customerPhone", invoice.OrderCustomer.CustomerPhone);
                    command.Parameters["@customerPhone"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@customerId", MySqlDbType.Int32);
                    command.Parameters["@customerId"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    invoice.OrderCustomer.CustomerId = (int)command.Parameters["@customerId"].Value;
                    if(invoice.OrderCustomer.CustomerId == null)
                    {
                        throw new Exception("Can't find this Customer!");
                    }
                    //Insert Invoice
                    command = new MySqlCommand("sp_createInvoice",connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId",invoice.OrderCustomer.CustomerId);
                    command.Parameters["@CustomerId"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@StaffId",invoice.InvoiceStaff.StaffID);
                    command.Parameters["@StaffId"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@Datetime",invoice.InvoiceDatetime);
                    command.Parameters["@Datetime"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@Status",invoice.InvoiceStatus);
                    command.Parameters["@Status"].Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.AddWithValue("@InvoiceNo", MySqlDbType.Int32);
                    command.Parameters["@InvoiceNo"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    invoice.InvoiceNo = (int)command.Parameters["@InvoiceNo"].Value;
                    reader = command.ExecuteReader();

                    foreach (Iphone iphone in invoice.IphoneList)
                    {
                        if(iphone.IphoneID == null)
                        {
                            throw new Exception("Not Exists Iphone");
                        }
                        if(iphone.Amount <=0)
                        {
                            throw new Exception("Not enough amount");
                        }
                        //get unit_price
                        command.CommandText = "select unit_price from iphones where iphone_id = @iphoneId;";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@iphoneId",iphone.IphoneID);
                        reader = command.ExecuteReader();
                        if(!reader.Read())
                        {
                            throw new Exception("Not Exits Iphone");
                        }
                        iphone.IphonePrice = reader.GetDouble("unit_price");
                        reader.Close();

                        //Insert InvoiceDetails
                        command.CommandText = @"insert into invoicedetails(invoice_no,iphone_id,quantity,unit_price) values (@invoiceNo,@iphoneId,@Quantity,@Unitprice)";
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@InvoiceNo",invoice.InvoiceNo);
                        command.Parameters.AddWithValue("@IphoneId",invoice.IphoneInvoice.IphoneID);
                        command.Parameters.AddWithValue("@Quantity",invoice.Quantity);
                        command.Parameters.AddWithValue("@Unitprice",iphone.IphonePrice);
                        command.ExecuteNonQuery();
                        //update amount
                        // command.CommandText = "update iphones set amount=amount-@quantity where iphone_id="+iphone.IphoneID + ";";
                        // command.Parameters.Clear();
                        // command.Parameters.AddWithValue("@quantity",iphone.Amount);
                        // command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    result = true;
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch{}
                }
                finally
                {
                    command.CommandText = "unlock tables;";
                    command.ExecuteNonQuery();
                }
            }
            catch{}
            finally
            {
                connection.Close();
            }
            return result;
        }
        public List<Invoice> GetAllInvoice()
        {
            List<Invoice> lst = null;
            lock (connection)
            {
                connection.Open();
                string scommand = "select invoicedetails.invoice_no,iphone_name,color_name,quantity,unit_price,customer_name,invoices.invoice_status from invoicedetails,iphones,invoices,customers,staffs,colors where invoicedetails.iphone_id = iphones.iphone_id and invoices.invoice_no = invoicedetails.invoice_no and invoices.customer_id = customers.customer_id and invoices.staff_id = staffs.staff_id and colors.color_id = iphones.color_id;";
                MySqlCommand command = new MySqlCommand(scommand,connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                    Console.WriteLine("|  ___   _______  __   __  _______  __    _  _______    _______  _______  _______  ______    _______   |");
                    Console.WriteLine("| |   | |       ||  | |  ||       ||  |  | ||       |  |       ||       ||       ||    _ |  |       |  |");
                    Console.WriteLine("| |   | |    _  ||  |_|  ||   _   ||   |_| ||    ___|  |  _____||_     _||   _   ||   | ||  |    ___|  |");
                    Console.WriteLine("| |   | |   |_| ||       ||  | |  ||       ||   |___   | |_____   |   |  |  | |  ||   |_||_ |   |___   |");
                    Console.WriteLine("| |   | |    ___||       ||  |_|  ||  _    ||    ___|  |_____  |  |   |  |  |_|  ||    __  ||    ___|  |");
                    Console.WriteLine("| |   | |   |    |   _   ||       || | |   ||   |___    _____| |  |   |  |       ||   |  | ||   |___   |");
                    Console.WriteLine("| |___| |___|    |__| |__||_______||_|  |__||_______|  |_______|  |___|  |_______||___|  |_||_______|  |");
                    Console.WriteLine("|                                                                                                      |");
                    Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                    Console.WriteLine("| No  | IphoneName           | Color        | Quantity   | Price           | CustomerName    | Status  |");
                    Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                    while(reader.Read())
                    {
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        string no = reader["invoice_no"].ToString();
                        string name = reader["iphone_name"].ToString();
                        string color = reader["color_name"].ToString();
                        string quantity = reader["quantity"].ToString();
                        string price = reader["unit_price"].ToString();
                        string cusname = reader["customer_name"].ToString();
                        string status = reader["invoice_status"].ToString();
                        Console.WriteLine("| {0,-3} | {1,-20} | {2,-12} | {3,-10} | {4,-15} | {5,-15} | {6,-7} |",no,name,color,quantity,price,cusname,status);
                    }
                    Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                    Console.WriteLine("Press any key to back Invoice menu");
                    reader.Close();
                }
                connection.Close();
            }
            return lst;
        }
        public Invoice GetInvoiceByID(int invoiceNo)
        {
            Invoice invoice = null;
            lock (connection)
            {
                try
                {
                    connection.Open();
                    // query = @"select * from invoices where invoice_no =@invoiceNo";
                    query = @"select invoicedetails.invoice_no,invoice_data,iphone_name,color_name,customer_address,customer_email,customer_phone,quantity,unit_price,customer_name,staff_name,role,invoices.invoice_status from invoicedetails,iphones,invoices,customers,staffs,colors where invoicedetails.iphone_id = iphones.iphone_id and invoices.invoice_no = invoicedetails.invoice_no and invoices.customer_id = customers.customer_id and invoices.staff_id = staffs.staff_id and colors.color_id = iphones.color_id and invoices.invoice_no = @invoiceNo;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                    MySqlDataReader reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        invoice = GetInvoice(reader);
                    }
                    reader.Close();
                }
                catch { }
                finally
                {
                    connection.Close();
                }
            }
            return invoice;
        }
        public Invoice GetInvoice(MySqlDataReader reader)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceNo =reader.GetInt32("invoice_no");
            invoice.InvoiceDatetime = reader.GetDateTime("invoice_data");
            invoice.IphoneInvoice = new Iphone()
            {
                IphoneName = reader.GetString("iphone_name"),
                IphoneColor = reader.GetString("color_name")
            };
            invoice.OrderCustomer = new Customer()
            {
                CustomerName = reader.GetString("customer_name"),
                CustomerAddress = reader.GetString("customer_address"),
                CustomerEmail = reader.GetString("customer_email"),
                CustomerPhone = reader.GetString("customer_phone")
            };
            invoice.InvoiceStaff = new Staff()
            {
                StaffName = reader.GetString("staff_name"),
                Role = reader.GetInt32("role")
            };
            invoice.Quantity = reader.GetInt32("quantity");
            invoice.UnitPrice = reader.GetDouble("unit_price");
            invoice.InvoiceStatus = reader.GetInt32("invoice_status");
            return invoice;
        }
        public int? AddInvoice(Invoice invoice)
        {
            int? result = null;
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand("sp_createInvoice",connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId",invoice.OrderCustomer.CustomerId);
                command.Parameters["@CustomerId"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@StaffId",invoice.InvoiceStaff.StaffID);
                command.Parameters["@StaffId"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@Datetime",invoice.InvoiceDatetime);
                command.Parameters["@Datetime"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@Statuss",invoice.InvoiceStatus);
                command.Parameters["@Statuss"].Direction = System.Data.ParameterDirection.Input;
                command.Parameters.AddWithValue("@InvoiceNo", MySqlDbType.Int32);
                command.Parameters["@InvoiceNo"].Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();
                result = (int)command.Parameters["@InvoiceNo"].Value;
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
        public int? AddInvoiceDetails(Invoice invoice)
        {
            int? result = null;
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            MySqlCommand command = new MySqlCommand("insert into invoicedetails(invoice_no,iphone_id,quantity,unit_price) values (@invoiceNo,@iphoneId,@Quantity,@Unitprice);",connection);
            try
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@InvoiceNo",invoice.InvoiceNo);
                command.Parameters.AddWithValue("@IphoneId",invoice.IphoneInvoice.IphoneID);
                command.Parameters.AddWithValue("@Quantity",invoice.Quantity);
                command.Parameters.AddWithValue("@Unitprice",invoice.UnitPrice);
                command.ExecuteNonQuery();
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