using System;

namespace DataLayer.BillingBoundedContext
{
    public class InvoiceReference
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerReference Customer { get; set; }
        public decimal Amount { get; set; }
    }
}