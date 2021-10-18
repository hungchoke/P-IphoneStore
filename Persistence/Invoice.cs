using System;
using System.Collections.Generic;

namespace Persistence
{
    public static class InvoiceStatus
    {
        public const int CREATE_NEW_ORDER = 1;
        public const int INVOICE_INPROGRESS = 2;
    }
    public class Invoice
    {
        public int? InvoiceNo {set;get;}
        public DateTime InvoiceDatetime {set; get;}
        public Customer OrderCustomer {set; get;}
        public int InvoiceStatus {set; get;}
        public int Quantity {set; get;}
        public double UnitPrice {set; get;}
        public Staff InvoiceStaff {set; get;}
        public Iphone IphoneInvoice {set;get;}
        public List<Iphone> IphoneList {set;get;}

        public Iphone this[int index]
        {
            get
            {
                if (IphoneList == null || IphoneList.Count == 0 || IphoneList.Count < index) return null;
                return IphoneList[index];
            }
            set
            {
                if (IphoneList == null) IphoneList = new List<Iphone>();
                IphoneList.Add(value);
            }
        }
        public Invoice()
        {
            IphoneList = new List<Iphone>();
        }
        
        public override bool Equals(object obj){
            if(obj is Invoice)
            {
                return ((Invoice)obj).InvoiceNo.Equals(InvoiceNo);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return InvoiceNo.GetHashCode();
        }
    }
}