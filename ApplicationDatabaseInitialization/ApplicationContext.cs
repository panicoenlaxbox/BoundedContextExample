using System.Data.Entity;
using System.Reflection;
using DataLayer.ApplicationDatabaseInitialization.Migrations;
using DataLayer.Mappings;
using Domain.Entities;

namespace DataLayer.ApplicationDatabaseInitialization
{
    public class ApplicationContext : DbContext
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
        }

        #region Sales
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Billing
        public DbSet<Invoice> Invoices { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(CustomerMap)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
