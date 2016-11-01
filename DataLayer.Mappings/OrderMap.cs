using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundeContext]
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
        }
    }
}