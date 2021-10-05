using Xunit;
using DAL;
using Persistence;
using System.Collections.Generic;

namespace DALTest
{
    public class IphoneDALTest
    {
    
        private const int FOUND = 1;
        private const int NOT_FOUND = 0;
        private const int MATCH = 1;
        private const int NOT_MATCH = 0;
        private IphoneDAL idal = new IphoneDAL();

        [Theory]
        [InlineData(1,FOUND)]
        [InlineData(2,FOUND)]
        [InlineData(4,FOUND)]
        [InlineData(5,FOUND)]
        [InlineData(3,FOUND)]
        [InlineData(6,FOUND)]
        [InlineData(9,FOUND)]
        [InlineData(7,FOUND)]
        [InlineData(8,FOUND)]
        [InlineData(10,FOUND)]
        [InlineData(11,FOUND)]
        [InlineData(12,FOUND)]
        [InlineData(13,FOUND)]
        [InlineData(14,FOUND)]
        [InlineData(15,FOUND)]
        [InlineData(16,FOUND)]
        [InlineData(100,NOT_FOUND)]
        private void SearchByIDTest(int id,int expected)
        {
            Iphone result = idal.GetIphoneById(id);
            if(expected == FOUND)
            {
                Assert.True(result != null);
                Assert.True(result.IphoneID == id);
            }
            else
            {
                Assert.True(result == null);
            }
                
        }
        


        [Theory]
        [InlineData("Iphone",MATCH)]
        [InlineData("Iphone 11",MATCH)]
        [InlineData("Iphone 12",MATCH)]
        [InlineData("",NOT_MATCH)]
        [InlineData("Iphpe",NOT_MATCH)]
        [InlineData("adknadk",NOT_MATCH)]
        [InlineData("dsad",NOT_MATCH)]
        public void SearchByNameTest(string ipname,int expected)
        {
            Iphone iphone = new Iphone(){IphoneName = ipname};
            List<Iphone> result = idal.GetIphoneByName(ipname);
            if(expected == NOT_MATCH)
            {
                Assert.True(result == null);
            }
            else
            {
                Assert.True(result != null);
                Assert.True(result.Count == expected);
                foreach (Iphone ip in result)
                {
                    Assert.Contains(ipname.ToLower(),ip.IphoneName.ToLower());
                }
            }
        }
        
    }
}