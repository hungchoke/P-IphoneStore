using System;

namespace Persistence
{
    public class Iphone
    {
        public int IphoneID {set; get;}
        public string IphoneName {set; get;}
        public string IphoneProcess {set; get;}
        public string IphoneMemory {set; get;}
        public string IphoneColor {set; get;}
        public string IphoneStorage {set; get;}
        public string IphoneCammera {set; get;}
        public string IphoneBattery {set; get;}
        public string IphoneScreen {set; get;}
        public string IphoneNetwork {set; get;}
        public string IphoneWireless {set; get;}
        public string IphoneWaterproof {set; get;}
        public string IphoneSupport {set; get;}
        public double IphonePrice {set; get;}

        public override bool Equals(object obj)
        {
            if (obj is Iphone)
            {
                return ((Iphone)obj).IphoneID.Equals(IphoneID);
            }
            return false;    
        }

        public override int GetHashCode()
        {
            return IphoneID.GetHashCode();
        }
    }
}