using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApplicationDatabaseInitialization;
using DataLayer.BillingBoundedContext;
using Domain.Entities;

namespace BoundedContextExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                Invoice invoice = context.Invoices.First();
                Console.WriteLine(invoice.Id);
            }
            using (var context = new BillingContext())
            {
                InvoiceReference invoice = context.Invoices.First();
                Console.WriteLine(invoice.Id);
                CustomerReference customer = invoice.Customer;
                Console.WriteLine(customer.Id);
                context.Invoices.Remove(invoice);
                var newInvoice = new InvoiceReference()
                {
                    Id = invoice.Id,
                    CustomerId = customer.Id,
                    Amount = 100m
                };
                context.Invoices.Add(newInvoice);
                context.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
