using System;
using Xunit;
using DAL;
using Persistence;

namespace DALTest
{
    public class StaffDalTest
    {
        private const int LOGIN_SALE = 1;
        private const int LOGIN_ACCOUNTANT = 2;
        private const int LOGIN_FAIL = 0;

        private StaffDAL sdal = new StaffDAL();
        [Theory]
        [InlineData("Sale", "Hungstaff2", LOGIN_SALE)]
        [InlineData("Accountant", "Hoangstaff1", LOGIN_ACCOUNTANT)]
        [InlineData("Sale", "Hungstaff1ea", LOGIN_FAIL)]
        [InlineData("Acaffa", "Hoangstaff1", LOGIN_FAIL)]
        [InlineData("Accountant", "HoangstaffBH1@", LOGIN_FAIL)]
        [InlineData("Sale", "", LOGIN_FAIL)]
        [InlineData("", "Hoangstaff1", LOGIN_FAIL)]
        [InlineData("da","dadja32",LOGIN_FAIL)]
        public void LoginTest(string UsName,string PsWord,int expected)
        {
            Staff staff = new Staff() {UserName = UsName, Password = PsWord};
            int result = sdal.Login(staff).Role;
            Assert.True(result == expected);
        }
    }        
}