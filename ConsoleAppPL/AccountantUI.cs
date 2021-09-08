using System;

namespace ConsoleAppPL
{
    public class AccountantUI
    {
        public void DisplayAccountantMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("|--------ACCOUNTANT MENU--------|");
                Console.WriteLine("=================================");
                Console.WriteLine("|1. Export Invoice              |");
                Console.WriteLine("|2. Payment                     |");
                Console.WriteLine("|3. Logout                      |");
                Console.WriteLine("=================================");
                Console.Write("Your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        Console.WriteLine("SEE YOU LATER!");
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