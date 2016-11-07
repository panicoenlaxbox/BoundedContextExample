using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundedContext]
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {

        }
    }
}
