using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class InvoiceBL
    {
        private InvoiceDAL indl = new InvoiceDAL();
        public bool CreateInvoice(Invoice invoice)
        {
            bool result = indl.CreateInvoice(invoice);
            return result;
        }
        public Invoice GetInvoiceById(int invoiceNo)
        {
            return indl.GetInvoiceByID(invoiceNo);
        }
        public int? AddInvoice(Invoice invoice)
        {
            return indl.AddInvoice(invoice) ?? 0;
        }
        public int? AddInvoiceDetails(Invoice invoice)
        {
            return indl.AddInvoiceDetails(invoice) ?? 0;
        }
        public List<Invoice> GetAllInvoice()
        {
            return indl.GetAllInvoice();
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceBL bL &&
                   EqualityComparer<InvoiceDAL>.Default.Equals(indl, bL.indl);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(indl);
        }
    }
}