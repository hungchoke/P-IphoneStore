using System;
using Persistence;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    public class AccountantUI
    {
        
        
        public void DisplayAccountantMenu()
        {
            int choice;
            while (true)
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
                Console.WriteLine("|                                          ACCOUNTANT MENU                                             |");
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("|1. Customer Manager                                                                                   |");
                Console.WriteLine("|2. Export Invoice                                                                                     |");
                Console.WriteLine("|3. Logout                                                                                             |");
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        CustomerManager();
                        break;
                    case 2:
                        Invoice();
                        break;
                    case 3:
                        Program.LoginMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 3)");
                        break;     
                }
            }
        }
        
        public void CustomerManager()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                           INVOICE MENU                           |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. Show customer infomation by Id                                 |");
                Console.WriteLine("|2. Add customer infomation                                        |");
                Console.WriteLine("|3. Back to main menu                                              |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        SearchCustomerById();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        DisplayAccountantMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 3)");
                        break;     
                }
            }
        }
        public void AddCustomer()
        {
            
            CustomerBL cbl = new CustomerBL();
            Console.Write("Name: ");
            string cname = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Customer customer = new Customer(){CustomerName = cname,CustomerAddress = address,CustomerEmail = email,CustomerPhone = phone};
            int? id = cbl.AddCustomer(customer);
            Console.WriteLine("Add complete! id:{0}", id);
            Console.ReadKey();
        }
        public void AddInvoice()
        {
            
            InvoiceBL ivbl = new InvoiceBL();
            
            Console.Write("Customer ID: ");
            int cusid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Staff Id: ");
            int staffid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Status: ");
            int status = Convert.ToInt32(Console.ReadLine());
            Invoice invoice = new Invoice();
            invoice.OrderCustomer = new Customer(){CustomerId = cusid};
            invoice.InvoiceStaff = new Staff(){StaffID = staffid};
            invoice.InvoiceStatus = status;
            invoice.InvoiceDatetime = DateTime.Now;
            int? invno = ivbl.AddInvoice(invoice);
            invoice.InvoiceNo = invno;
            Console.WriteLine("Add complete! id:{0}", invno);
            Console.WriteLine("Invoice No: "+invno);
            Console.Write("Iphone Id: ");
            int iphoneid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unit Price: ");
            double unitprice = Convert.ToDouble(Console.ReadLine());
            Invoice invoice1 = new Invoice();
            invoice1.InvoiceNo = invno;
            invoice1.IphoneInvoice = new Iphone(){IphoneID = iphoneid};
            invoice1.Quantity = quantity;
            ivbl.AddInvoiceDetails(invoice1);
            Console.WriteLine("Add complete!");
            Console.ReadKey();
        }
        public void SearchCustomerById()
        {
            CustomerBL cbl = new CustomerBL();
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.Write("Input customer id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Customer ct = cbl.GetCustomerById(customerId);
            if (customerId <= 0)
            {
                Console.WriteLine("Id {0} does not exist,please re enter!",customerId);
                SearchCustomerById();
            }
            else
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                       CUSTOMERS INFOMATION                       |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("Name: "+ct.CustomerName);
                Console.WriteLine("Address: "+ct.CustomerAddress);
                Console.WriteLine("Email: "+ct.CustomerEmail);
                Console.WriteLine("Phone: "+ct.CustomerPhone);
                Console.WriteLine("+------------------------------------------------------------------+");
            }
            int choice;
            while (true)
            {
                
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. View other customer info                                       |");
                Console.WriteLine("|2. Back to Accountant menu                                        |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        SearchCustomerById();
                        Console.ReadLine();
                        break;
                    case 2:
                        DisplayAccountantMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 2)");
                        break;
                }
            }
        }
        public void Invoice()
        {
            InvoiceBL inbl = new InvoiceBL();
            int choice;
            while(true)
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
                Console.WriteLine("|                                            INVOICE                                                   |");
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("|1.Create new invoice                                                                                  |");
                Console.WriteLine("|2.Show invoice by no                                                                                  |");
                Console.WriteLine("|3.Show all invoice                                                                                    |");
                Console.WriteLine("|4.Back to Accountant menu                                                                             |");
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        CreateNewInvoice();
                        break;
                    case 2:
                        ViewInvoiceByInvoiceNo();
                        break;
                    case 3:
                        inbl.GetAllInvoice();
                        Console.ReadLine();
                        break;
                    case 4:
                        DisplayAccountantMenu();
                        break;
                    default:
                        break;    
                }
            }    
        }
        public void CreateNewInvoice()
        {
            CustomerBL cbl = new CustomerBL();
            Staff staff = new Staff();
            IphoneBL ibl = new IphoneBL();
            InvoiceBL ivbl = new InvoiceBL();
            // Iphone iphone = new Iphone();
            Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|  ___   _______  __   __  _______  __    _  _______    _______  _______  _______  ______    _______   |");
            Console.WriteLine("| |   | |       ||  | |  ||       ||  |  | ||       |  |       ||       ||       ||    _ |  |       |  |");
            Console.WriteLine("| |   | |    _  ||  |_|  ||   _   ||   |_| ||    ___|  |  _____||_     _||   _   ||   | ||  |    ___|  |");
            Console.WriteLine("| |   | |   |_| ||       ||  | |  ||       ||   |___   | |_____   |   |  |  | |  ||   |_||_ |   |___   |");
            Console.WriteLine("| |   | |    ___||       ||  |_|  ||  _    ||    ___|  |_____  |  |   |  |  |_|  ||    __  ||    ___|  |");
            Console.WriteLine("| |   | |   |    |   _   ||       || | |   ||   |___    _____| |  |   |  |       ||   |  | ||   |___   |");
            Console.WriteLine("| |___| |___|    |__| |__||_______||_|  |__||_______|  |_______|  |___|  |_______||___|  |_||_______|  |");
            Console.WriteLine("|                                                                                                      |");
            Console.WriteLine("|                                              CREATE INVOICE                                          |");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
            Console.Write("Name: ");
            string cusname = Console.ReadLine();
            Console.Write("Address: ");
            string cusadd = Console.ReadLine();
            Console.Write("Email: ");
            string cusemail = Console.ReadLine();
            Console.Write("Number: ");
            string cusphone = Console.ReadLine();
            Customer customer = new Customer(){CustomerName = cusname,CustomerAddress = cusadd,CustomerEmail = cusemail,CustomerPhone = cusphone};
            int? cusid = cbl.AddCustomer(customer);
            Console.WriteLine("Add complete! Customer id:{0}", cusid);
            Console.WriteLine("Customer ID: "+cusid);
            Console.Write("Staff Id: ");
            int staffid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Status: ");
            int status = Convert.ToInt32(Console.ReadLine());
            Invoice invoice = new Invoice();
            invoice.OrderCustomer = new Customer(){CustomerId = cusid};
            invoice.InvoiceStaff = new Staff(){StaffID = staffid};
            invoice.InvoiceStatus = status;
            invoice.InvoiceDatetime = DateTime.Now;
            int? invno = ivbl.AddInvoice(invoice);
            Console.WriteLine("Add complete! Invoice No:{0}", invno);
            Console.WriteLine("Invoice No: "+invno);
            Console.Write("Iphone Id: ");
            int iphoneid = Convert.ToInt32(Console.ReadLine());
            Iphone iphone = ibl.GetIphoneById(iphoneid);
            Console.Write("Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unit Price: "+iphone.IphonePrice);
            Invoice invoice1 = new Invoice();
            invoice1.InvoiceNo = invno;
            invoice1.IphoneInvoice = new Iphone(){IphoneID = iphoneid};
            invoice1.Quantity = quantity;
            invoice1.UnitPrice = iphone.IphonePrice;
            ivbl.AddInvoiceDetails(invoice1);
            Console.WriteLine("Add complete!");
            
            Invoice invoice2 = new Invoice();
            invoice2.InvoiceDatetime = DateTime.Now;
            invoice2.InvoiceStaff = new Staff(){StaffID = staffid};
            invoice2.OrderCustomer = new Customer(){CustomerId = cusid};
            invoice2.InvoiceStatus = status;
            invoice2.InvoiceNo = invno;
            invoice2.IphoneList.Add(ibl.GetIphoneById(iphoneid));
            invoice2.IphoneList[0].Amount = quantity;
            invoice2.UnitPrice = iphone.IphonePrice;
            invoice2.IphoneInvoice =new Iphone(){IphoneID = iphoneid};
            Console.WriteLine("Create Order: " + (ivbl.CreateInvoice(invoice2)? "completed!" : "not complete!"));
            ViewInvoiceByInvoiceNo();
        }
        public void ViewInvoiceByInvoiceNo()
        {
            InvoiceBL ibl = new InvoiceBL();
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.Write("Input invoice no: ");
            int invoiceNo = Convert.ToInt32(Console.ReadLine());
            Invoice iv = ibl.GetInvoiceById(invoiceNo);
            if (invoiceNo <=0)
            {
                Console.WriteLine("Id does not exist,please re enter!");
                ViewInvoiceByInvoiceNo();
            }
            else
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                // Console.WriteLine("Invoice No: "+iv.InvoiceNo);
                // Console.WriteLine("Datetime: "+iv.InvoiceDatetime);
                // Console.WriteLine("Customer Name: "+iv.OrderCustomer.CustomerName);
                // Console.WriteLine("Staff: "+iv.InvoiceStaff.StaffName);
                // Console.WriteLine("Iphone Name: "+iv.IphoneInvoice.IphoneName);
                // Console.WriteLine("Color: "+iv.IphoneInvoice.IphoneColor);
                // Console.WriteLine("Quantity: "+iv.Quantity);
                // Console.WriteLine("Unit Price: "+iv.UnitPrice);
                double total = iv.Quantity * iv.UnitPrice;
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("|  ___   _______  __   __  _______  __    _  _______    _______  _______  _______  ______    _______   |");
                Console.WriteLine("| |   | |       ||  | |  ||       ||  |  | ||       |  |       ||       ||       ||    _ |  |       |  |");
                Console.WriteLine("| |   | |    _  ||  |_|  ||   _   ||   |_| ||    ___|  |  _____||_     _||   _   ||   | ||  |    ___|  |");
                Console.WriteLine("| |   | |   |_| ||       ||  | |  ||       ||   |___   | |_____   |   |  |  | |  ||   |_||_ |   |___   |");
                Console.WriteLine("| |   | |    ___||       ||  |_|  ||  _    ||    ___|  |_____  |  |   |  |  |_|  ||    __  ||    ___|  |");
                Console.WriteLine("| |   | |   |    |   _   ||       || | |   ||   |___    _____| |  |   |  |       ||   |  | ||   |___   |");
                Console.WriteLine("| |___| |___|    |__| |__||_______||_|  |__||_______|  |_______|  |___|  |_______||___|  |_||_______|  |");
                Console.WriteLine("|                                                                                                      |");
                Console.WriteLine("|                                             INVOICE NO:{0,-3}           Datetime: {1,-21} |",iv.InvoiceNo,iv.InvoiceDatetime);
                Console.WriteLine("|                                                                    CustomerName: {0,-20}|",iv.OrderCustomer.CustomerName);
                Console.WriteLine("|                                                        Address: {0,-15} Phone: {1,-13} |",iv.OrderCustomer.CustomerAddress,iv.OrderCustomer.CustomerPhone);
                Console.WriteLine("|                                                                          Email: {0,-20} |",iv.OrderCustomer.CustomerEmail);
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("| Iphone Name          | Color          | Quantity     | Unit Price            | Total                 |");
                Console.WriteLine("| {0,-20} | {1,-14} | {2,-12} | {3,-21} | {4,-21} |",iv.IphoneInvoice.IphoneName,iv.IphoneInvoice.IphoneColor,iv.Quantity,iv.UnitPrice,total);
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("| Staff Name: {0,-20}                                                                     |",iv.InvoiceStaff.StaffName);
                
                if(iv.InvoiceStaff.Role == 1)
                {
                    Console.WriteLine("| Role: Sale                                                                                           |");
                }
                else
                {
                    Console.WriteLine("| Role: Accountant                                                                                     |");
                }
                if(iv.InvoiceStatus == 0)
                {
                    Console.WriteLine("| Status: Cancel order!                                                                                |");
                }
                else
                {
                    Console.WriteLine("| Status: Success!                                                                                     |");
                }
                Console.ReadKey();
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                int choices;
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("|1. View other invoice                                                                                 |");
                Console.WriteLine("|2. Back to Accountant menu                                                                            |");
                Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choices = Convert.ToInt32(Console.ReadLine());
                switch(choices)
                {
                    case 1:
                        ViewInvoiceByInvoiceNo();
                        break;
                    case 2:
                        DisplayAccountantMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 2)");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}