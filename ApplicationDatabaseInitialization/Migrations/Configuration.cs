using System.Collections.Generic;
using Domain.Entities;

namespace DataLayer.ApplicationDatabaseInitialization.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DataLayer.ApplicationDatabaseInitialization.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.ApplicationDatabaseInitialization.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.Customers.Any())
            {
                return;
            }
            var customer = new Customer { Name = "Acme", Email = "customer@acme.com" };
            context.Customers.Add(customer);
            var product = new Product { Description = "TNT" };
            context.Products.Add(product);
            var order = new Order
            {
                Customer = customer
            };
            order.AddLine(product, 5, 10m);
            context.Orders.Add(order);
            var invoice = new Invoice
            {
                Order = order,
                Customer = order.Customer,
                Amount = order.GetAmount()
            };
            context.Invoices.Add(invoice);
        }
    }
}
