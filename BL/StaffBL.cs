using System;
using Persistence;
using DAL;
using System.Text.RegularExpressions;

namespace BL
{
    public class StaffBL
    {
        private StaffDAL dal = new StaffDAL();
        public Staff Login(Staff staff
        ){
            
            return dal.Login(staff);
        }


        public bool ValidateUserName(string userName, out string ErrorMessage)
        {
            var input = userName;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(input))
            {
                // throw new Exception("Password should not be empty");
                ErrorMessage = "User Name should not be empty and whitespace";
                return false;
            }

            // var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            // var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
       
            if (!hasUpperChar.IsMatch(input) && !hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "User Name should contain a letter";
                return false;
            }
            // else if (!hasMiniMaxChars.IsMatch(input))
            // {
            //     ErrorMessage = "User Name should not be less than or greater than 12 characters";
            //     return false;
            // }
            // else if (!hasNumber.IsMatch(input))
            // {
            //     ErrorMessage = "User Name should contain At least one numeric value";
            //     return false;
            // }
            else
            {
                return true;
            }
        }
        
        public bool ValidatePassWord(string passWord, out string ErrorMessage)
        {
            var input = passWord;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(input))
            {
                // throw new Exception("Password should not be empty");
                ErrorMessage = "Password should not be empty and whitespace";
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
       
            if (!hasUpperChar.IsMatch(input) && !hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password must contain at least 1 lowercase character, 1 uppercase character!";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than 8 or larger than 15 characters!";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}