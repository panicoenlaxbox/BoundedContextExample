using System;

namespace Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}