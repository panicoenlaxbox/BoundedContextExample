using System;

namespace Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public virtual Order Order { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"Invoice {Id}, {CustomerId}, {Amount}";
        }
    }
}