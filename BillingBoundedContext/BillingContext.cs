using System.Data.Entity;
using System.Reflection;

namespace DataLayer.BillingBoundedContext
{
    public class BillingContext : BaseContext<BillingContext>
    {
        public DbSet<InvoiceReference> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}