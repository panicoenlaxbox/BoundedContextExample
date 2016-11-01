using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundeContext]
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
        }
    }
}