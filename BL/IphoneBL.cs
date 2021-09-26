using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class IphoneBL
    {
        private IphoneDAL idal = new IphoneDAL();
        public Iphone GetIphoneById(int iphoneId)
        {
            return idal.GetIphoneById(iphoneId);
        }

        public List<Iphone> GetAll()
        {
            return idal.GetAllIphone();
        }
        public List<Iphone> GetByName(string iphoneName)
        {
            return idal.GetIphones(IphoneFilter.FILTER_BY_ITEM_NAME, new Iphone{IphoneName = iphoneName});
        }
        public bool ValidName(string name, out string ErrorMessage)
        {
            var input = name;
            ErrorMessage = string.Empty;
            if(string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Please do not leave the input blank!";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}