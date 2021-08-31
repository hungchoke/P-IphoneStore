using System;
using Persistence;
using DAL;

namespace BL
{
    public class StaffBL
    {
        private StaffDAL dal = new StaffDAL();
        public int Login(Staff staff){
            return dal.Login(staff);
        }
    }
}