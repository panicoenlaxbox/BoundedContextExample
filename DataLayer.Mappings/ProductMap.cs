using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings.ApplicationDatabaseInitialization
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
        }
    }
}