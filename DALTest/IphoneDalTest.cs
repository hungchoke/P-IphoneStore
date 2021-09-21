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
        private void SearchByIDTest(int id,string iname)
        {
            Iphone result = idal.GetIphoneById(id);
            Assert.True(result != null);
            Assert.True(result.IphoneID == id);
            Assert.True(result.IphoneName.Equals(iname));
        }
    }
}