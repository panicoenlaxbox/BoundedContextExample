using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using DataLayer.Mappings;
using Domain.Entities;

namespace DataLayer.SalesBoundedContext
{
    public class SalesContext : BoundedContext<SalesContext>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var maps = Assembly.GetAssembly(typeof(CustomerMap)).GetTypes().Where(t => t.GetCustomAttribute<SalesBoundedContextAttribute>() != null).ToList();
            maps.ForEach(m => modelBuilder.Configurations.Add((dynamic) Activator.CreateInstance(m)));
            base.OnModelCreating(modelBuilder);
        }
    }
}