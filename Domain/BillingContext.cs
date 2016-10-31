using System.Data.Entity;

namespace Domain
{
    public class BillingContext : BaseContext<BillingContext>
    {
        public DbSet<Invoice> Invoices { get; set; }
    }
}