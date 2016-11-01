using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundeContext]
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {

        }
    }
}
