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
                Console.WriteLine("|===============================|");
                Console.WriteLine("|         IPHONE STORE          |");
                Console.WriteLine("|          SALE MENU            |");
                Console.WriteLine("|===============================|");
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
            
            int choice;
            while(true)
            {
                IphoneBL ibl = new IphoneBL();
                List<Iphone> lst;
                Console.WriteLine("|===============================|");
                Console.WriteLine("|         IPHONE STORE          |");
                Console.WriteLine("|          SHOW IPHONE          |");
                Console.WriteLine("|===============================|");
                Console.WriteLine("|1. View iphone by id           |");
                Console.WriteLine("|2. View all iphone             |");
                Console.WriteLine("|3. Back to Main menu           |");
                Console.WriteLine("=================================");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ViewIphoneById();
                        break;
                    case 2:
                        lst = ibl.GetAll();
                        Console.ReadLine();
                        break;
                    case 3:
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
            Console.WriteLine("=============================================");
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
                Console.WriteLine("|===========================================|");
                Console.WriteLine("|               IPHONE STORE                |");
                Console.WriteLine("|             IPHONE INFOMATION             |");
                Console.WriteLine("|===========================================|");
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
                Console.WriteLine("=============================================");
            }

            
            int choice;
            while (true)
            {
                Console.WriteLine("|===============================|");
                Console.WriteLine("|         IPHONE STORE          |");
                Console.WriteLine("|       IPHONE INFOMATION       |");
                Console.WriteLine("|===============================|");
                Console.WriteLine("|1. Add product in order        |");
                Console.WriteLine("|2. Back to Sale menu           |");
                Console.WriteLine("=================================");
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
        public void ViewAllIphone()
        {
            IphoneBL ibl = new IphoneBL();
            Iphone iphone = new Iphone();
            List<Iphone> IpList = ibl.GetAll();
            Console.Clear();
            Console.WriteLine("\nAll Iphone\n");
            int count = IpList.Count;
            if(count == 0)
            {
                Console.WriteLine("Your store is empty,please input iphone in the database");
            }
            else
            {
                Console.WriteLine("ID\tName\tMemory\tStorage\tPrice");
                Console.WriteLine("Name: "+iphone.IphoneName);
                
            }
        }
        public void ViewIphoneByColor()
        {

        }
    }
}