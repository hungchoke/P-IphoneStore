using System;

namespace ConsoleAppPL
{
    public class SaleUI
    {
        public void DisplaySaleMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Sale Menu");
                Console.WriteLine("============");
                Console.WriteLine("1. Show Iphone");
                Console.WriteLine("2. Order");
                Console.WriteLine("3. Exit");
                Console.WriteLine("============");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Environment.Exit(0);
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose again(1 - 3)");
                        break;     
                }
            }
        }
    }
}