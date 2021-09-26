using Xunit;
using DAL;
using Persistence;

namespace DALTest
{
    public class IphoneDALTest
    {
        private IphoneDAL idal = new IphoneDAL();

        [Theory]
        [InlineData(1,"Iphone 11")]
        [InlineData(2,"Iphone 11")]
        [InlineData(4,"Iphone 11")]
        [InlineData(5,"Iphone 11")]
        [InlineData(3,"Iphone 11")]
        [InlineData(6,"Iphone 11")]
        [InlineData(9,"Iphone 12")]
        [InlineData(7,"Iphone 12")]
        [InlineData(8,"Iphone 12")]
        [InlineData(10,"Iphone 12")]
        [InlineData(11,"Iphone 12")]
        [InlineData(12,"Iphone 12")]
        [InlineData(20,"Iphone 12 Pro Max")]
        private void SearchByIDTest(int id,string iname)
        {
            Iphone result = idal.GetIphoneById(id);
            Assert.True(result != null);
            Assert.True(result.IphoneID == id);
            Assert.True(result.IphoneName.Equals(iname));
        }
        

        // private IphoneDAL sdal = new IphoneDAL();
        // [Theory]
        // [InlineData("iphone",1)]
        // [InlineData("iphone 11",1)]
        // [InlineData("iphone 12",1)]
        // [InlineData("",0)]
        // [InlineData("Iphpe",0)]
        // [InlineData("adknadk",0)]
        // [InlineData("dsad",0)]
        // public void SearchByNameTest(string ipname,int expected)
        // {
        //     Iphone result = sdal.GetIphoneByName(ipname);
        //     Assert.True(result != null);
        //     Assert.True(result.IphoneName == ipname);
        //     Assert.True(result.IphoneName.Equals(ipname));
        // }
        
    }
}