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
        public List<Iphone> GetIphoneByName(string iphoneName)
        {
            return idal.GetIphoneByName(iphoneName);
        }
    }
}