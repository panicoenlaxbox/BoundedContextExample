using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain
{
    public class Order
    {
        public Order()
        {
            Lines = new Collection<OrderLine>();
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<OrderLine> Lines { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}