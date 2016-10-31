using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.BillingBoundedContext
{
    public class InvoiceReferenceMap : EntityTypeConfiguration<InvoiceReference>
    {
        public InvoiceReferenceMap()
        {
            ToTable("Invoices");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}