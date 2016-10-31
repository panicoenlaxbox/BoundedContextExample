using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Customer
    {
        public Customer()
        {
            Orders = new Collection<Order>();
            Invoices = new Collection<Invoice>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}