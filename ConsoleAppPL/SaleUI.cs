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
            try
            {
                int choice;
                while (true)
                {
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("|                           IPHONE STORE                           |");
                    Console.WriteLine("|                             SALE MENU                            |");
                    Console.WriteLine("+------------------------------------------------------------------+");
                    Console.WriteLine("|1. Show Iphone                                                    |");
                    Console.WriteLine("|2. Order                                                          |");
                    Console.WriteLine("|3. Logout                                                         |");
                    Console.WriteLine("+------------------------------------------------------------------+");
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ShowIphone()
        {
            
            int choice;
            while(true)
            {
                IphoneBL ibl = new IphoneBL();
                List<Iphone> lst;
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                            SHOW MENU                             |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. View iphone by id                                              |");
                Console.WriteLine("|2. View all iphone                                                |");
                Console.WriteLine("|3. View iphone by name                                            |");
                Console.WriteLine("|4. Back to Main menu                                              |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ViewIphoneById();
                        Console.ReadKey();
                        break;
                    case 2:
                        lst = ibl.GetAll();
                        Console.ReadKey();
                        break;
                    case 3:
                        ViewIphoneByName();
                        Console.ReadKey();
                        break;
                    case 4:
                        DisplaySaleMenu();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 3)");
                        break;
                }
            }    
        }
        public void ViewIphoneById()
        {
            IphoneBL ibl = new IphoneBL();
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.WriteLine("Input iphone id: ");
            int iphoneId = Convert.ToInt32(Console.ReadLine());
            Iphone ip = ibl.GetIphoneById(iphoneId);
            if (iphoneId <=0)
            {
                Console.WriteLine("Id does not exist,please re enter!");
                ViewIphoneById();
            }
            else
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|                           IPHONE STORE                           |");
                Console.WriteLine("|                        IPHONE INFOMATION                         |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("Name: "+ip.IphoneName);
                Console.WriteLine("Memory: "+ip.IphoneMemory);
                Console.WriteLine("Color: "+ip.IphoneColor);
                Console.WriteLine("Process: "+ip.IphoneProcess);
                Console.WriteLine("Camera: "+ip.IphoneCamera);
                Console.WriteLine("Screen: "+ip.IphoneScreen);
                Console.WriteLine("Storage: "+ip.IphoneStorage);
                Console.WriteLine("Support: "+ip.IphoneSupport);
                Console.WriteLine("Battery: "+ip.IphoneBattery);
                Console.WriteLine("Waterproof: "+ip.IphoneWaterproof);
                Console.WriteLine("Wireless Network: "+ip.IphoneWirelessNetwork);
                Console.WriteLine("Price: "+ip.IphonePrice);
            }

            
            int choice;
            while (true)
            {
                
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.WriteLine("|1. Add product in order                                           |");
                Console.WriteLine("|2. Back to Sale menu                                              |");
                Console.WriteLine("+------------------------------------------------------------------+");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Sorry, this function is not build yet!");
                        break;
                    case 2:
                        DisplaySaleMenu();
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 2)");
                        break;
                }
            }
        }
        
        public void ViewIphoneByName()
        {
            // string name;
            // IphoneBL ibl = new IphoneBL();
            // Console.WriteLine("+------------------------------------------------------------------+");
            // Console.Write("Input iphone name: ");
            // name = Console.ReadLine();
            // List<Iphone> lst;
            // if(name == null)
            // {
            //     Console.WriteLine("No result found with {0}",name);
            // }
            // else
            // {
            //     Console.WriteLine("+---------------------------------------------------------------------------------+");
            //     Console.WriteLine("|                                  IPHONE STORE                                   |");
            //     Console.WriteLine("+---------------------------------------------------------------------------------+");
            //     Console.WriteLine("| ID | Name                 | Color        | Memory     | Storage    | Price      |");
            //     Console.WriteLine("+---------------------------------------------------------------------------------+");
            //     lst = ibl.GetByName(name);
            //     Console.WriteLine("+---------------------------------------------------------------------------------+");
            // }
            string name;
            IphoneBL ibl = new IphoneBL();
            List<Iphone> lst;
            Console.Write("Input iphone name: ");
            name = Console.ReadLine();
            lst = ibl.GetIphoneByName(name);
        }   
    }
}