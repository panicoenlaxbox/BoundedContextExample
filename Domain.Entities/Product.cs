using System.Collections.ObjectModel;

namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            OrderLines = new Collection<OrderLine>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public Collection<OrderLine> OrderLines { get; set; }
    }
}