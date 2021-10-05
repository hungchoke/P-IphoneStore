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
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                          ACCOUNTANT MENU                         |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. Export Invoice                                                 |");
                Console.WriteLine("|2. Payment                                                        |");
                Console.WriteLine("|3. Logout                                                         |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ExportInvoice();
                        break;
                    case 2:
                        Console.WriteLine("Sorry, this function is not build yet!");
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
        
        public void ExportInvoice()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                           INVOICE MENU                           |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. Add product                                                    |");
                Console.WriteLine("|2. Add customer infomation                                        |");
                Console.WriteLine("|3. Back to main menu                                              |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Sorry, this function is not build yet!");
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
    }
}