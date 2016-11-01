using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundeContext]
    public class OrderLineMap : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineMap()
        {
        }
    }
}