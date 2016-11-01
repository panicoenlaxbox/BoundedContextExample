using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain.Entities
{
    public class Order
    {
        public Order()
        {
            Lines = new Collection<OrderLine>();
        }
        public int Id { get; set; }
        public virtual ICollection<OrderLine> Lines { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }

        public void AddLine(Product product, int units, decimal price)
        {
            Lines.Add(new OrderLine()
            {
                Product = product,
                Units = units,
                Price = price
            });
        }

        public decimal GetAmount()
        {
            return Lines.Sum(p => p.Units * p.Price);
        }
    }
}