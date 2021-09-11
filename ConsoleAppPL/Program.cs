using System;
using Persistence;
using BL;
using System.Threading;

namespace ConsoleAppPL
{

    public class Program
    {
        static void Main(string[] args)
        {
            Login();
            // try
            // {
            //     SaleUI sui = new SaleUI();
            //     AccountantUI aui = new AccountantUI();
            //     Console.WriteLine("=================================");
            //     Console.WriteLine("|---------IPHONE STORE----------|");
            //     Console.WriteLine("=================================");

            //     Console.Write("User Name: ");
            //     string userName = Console.ReadLine();
            //     Console.Write("Password: ");
            //     string pass = GetPassword();
            //     Console.WriteLine();

            //     Staff staff = new Staff() { UserName = userName, Password = pass };
            //     StaffBL bl = new StaffBL();
            //     int login = bl.Login(staff).Role;
            //     if (pass.Length < 8)
            //     {
            //         Console.WriteLine("Password consists of 8 character or more!");
            //     }

            //     if (login <= 0)
            //     {
            //         Console.WriteLine("Can't Login");
            //     }
            //     else
            //     {
            //         if (staff.Role == 1)
            //         {
            //             Console.WriteLine("Login Success!!");
            //             Console.WriteLine("You are Sale!");
            //             sui.DisplaySaleMenu();
            //         }
            //         else
            //         {
            //             Console.WriteLine("Login Success!!");
            //             Console.WriteLine("You are Accountant!");
            //             aui.DisplayAccountantMenu();
            //         }

            //     }
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
        }

        public static string InputUserName()
        {
            StaffBL sbl = new StaffBL();
            string ErrorMessage;
            string userName;
            do
            {
                Console.Write("\nUser Name: ");
                userName = Console.ReadLine();
                sbl.ValidateUserName(userName, out ErrorMessage);

                if (ErrorMessage != null)
                {
                    Console.WriteLine(ErrorMessage);
                }
            }
            while (sbl.ValidateUserName(userName, out ErrorMessage) == false);

            return userName;
        }

        public static void Login()
        {
            try
            {
                SaleUI sui = new SaleUI();
                AccountantUI aui = new AccountantUI();
                Console.WriteLine("=================================");
                Console.WriteLine("|---------IPHONE STORE----------|");
                Console.WriteLine("=================================");

                string userName = InputUserName();
                Console.Write("Password: ");
                string pass = GetPassword();
                Console.WriteLine();

                Staff staff = new Staff() { UserName = userName, Password = pass };
                StaffBL bl = new StaffBL();
                int login = bl.Login(staff).Role;
                if (pass.Length < 8)
                {
                    Console.WriteLine("Password consists of 8 character or more!");
                }

                if (login <= 0)
                {
                    Console.WriteLine("Can't Login");
                }
                else
                {
                    if (staff.Role == 1)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Login Success!!");
                        Thread.Sleep(1000);
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
            catch (Exception e)
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
