using System.Data.Entity;
using Domain.Entities;

namespace DataLayer.SalesBoundedContext
{
    public class SalesContext : BaseContext<SalesContext>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}