using System;
using Persistence;
using BL;

namespace ConsoleAppPL
{
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SaleUI sui = new SaleUI();
                AccountantUI aui = new AccountantUI();
                Console.WriteLine("=================================");
                Console.WriteLine("|-------------LOGIN-------------|");
                Console.WriteLine("=================================");

                Console.Write("User Name: ");
                string userName = Console.ReadLine();
                Console.Write("Password: ");
                string pass = GetPassword();
                Console.WriteLine();
                
                Staff staff = new Staff(){UserName=userName, Password=pass};
                StaffBL bl = new StaffBL();
                int login = bl.Login(staff).Role;
                if(pass.Length<8)
                {
                    Console.WriteLine("Password consists of 8 character or more!");
                }
                if(login <= 0)
                {
                    Console.WriteLine("Can't Login");
                }else{
                    if(staff.Role == 1)
                    {
                        Console.WriteLine("Login Success!!");
                        Console.WriteLine("You are Sale!");
                        sui.DisplaySaleMenu();
                    }
                    else
                    {
                        Console.WriteLine("Login Success!!");
                        Console.WriteLine("You are Accountant!");
                        aui.DisplayAccountantMenu();
                    }
                    
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
    }
}
