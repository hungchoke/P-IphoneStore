using System;

namespace Persistence
{
    public class Staff
    {
        public int StaffID {set;get;}
        public string StaffName {set;get;}
        public string UserName {set;get;}
        public string Password {set;get;}
        public string Telephone {set;get;}
        public string Email {set; get;}
        public int Role {set;get;}

        public static int SALE_ROLE = 1;
        public static int ACCOUNTANCE_ROLE = 2;

        public override bool Equals(object obj){
            if(obj is Staff)
            {
                return ((Staff)obj).StaffID.Equals(StaffID);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return StaffID.GetHashCode();
        }
    }
}
