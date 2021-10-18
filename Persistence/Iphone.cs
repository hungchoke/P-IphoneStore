using System;

namespace Persistence
{
    public class Iphone
    {
        public int? IphoneID {set; get;}
        public string IphoneName {set; get;}
        public string IphoneProcess {set; get;}
        public string IphoneMemory {set; get;}
        public string IphoneColor {set; get;}
        public string IphoneStorage {set; get;}
        public string IphoneCamera {set; get;}
        public string IphoneBattery {set; get;}
        public string IphoneScreen {set; get;}
        public string IphoneWirelessNetwork {set; get;}
        public string IphoneWaterproof {set; get;}
        public string IphoneSupport {set; get;}
        public double IphonePrice {set; get;}
        public int Amount {set;get;}



        public override bool Equals(object obj){
            if(obj is Iphone)
            {
                return ((Invoice)obj).InvoiceNo.Equals(IphoneID);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return IphoneID.GetHashCode();
        }
    }
    public class Color
    {
        public int ColorID {set; get;}
        public string ColorName {set; get;}
        public int Quantity {set;get;}
    }
}