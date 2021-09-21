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
            return idal.GetIphones(IphoneFilter.GET_ALL,null);
        }
        public List<Iphone> GetByColor(int iphoneColor)
        {
            return idal.GetIphones(IphoneFilter.FILTER_BY_ITEM_COLOR,new Iphone{IphoneColor = iphoneColor});
        }
        
    }
}