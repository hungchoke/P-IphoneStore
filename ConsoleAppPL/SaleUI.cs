using System;
using Persistence;
using BL;
using System.Collections.Generic;

namespace ConsoleAppPL
{
    public class SaleUI
    {
        public void DisplaySaleMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("|----------SHOW IPHONE----------|");
                Console.WriteLine("=================================");
                Console.WriteLine("|1. Show Iphone                 |");
                Console.WriteLine("|2. Order                       |");
                Console.WriteLine("|3. Logout                      |");
                Console.WriteLine("=================================");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ShowIphone();
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
        public void ShowIphone()
        {
            IphoneBL ibl = new IphoneBL();
            List<Iphone> lst;
            Iphone ip = new Iphone();
            int choice;
            while(true)
            {
                
                Console.WriteLine("=================================");
                Console.WriteLine("|-----------SALE MENU-----------|");
                Console.WriteLine("=================================");
                lst = ibl.GetAll();
                Console.WriteLine("\nIphone count: "+lst.Count);
                Console.WriteLine("|1. View iphone infomation      |");
                Console.WriteLine("|2. Add new product             |");
                Console.WriteLine("|3. Back to Main menu           |");
                Console.WriteLine("=================================");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Sorry, this function is not build yet!");
                        break;
                    case 2:
                        Console.WriteLine("Sorry, this function is not build yet!");
                        break;
                    case 3:
                        DisplaySaleMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 3)");
                        break;
                }
            }    
        }
    }
}