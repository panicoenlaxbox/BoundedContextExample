using System.Data.Entity.ModelConfiguration;

namespace DataLayer.BillingBoundedContext
{
    public class CustomerReferenceMap : EntityTypeConfiguration<CustomerReference>
    {
        public CustomerReferenceMap()
        {
            ToTable("Customers");
        }
    }
}
