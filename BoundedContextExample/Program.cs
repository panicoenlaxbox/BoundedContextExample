using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApplicationDatabaseInitialization;
using DataLayer.BillingBoundedContext;
using DataLayer.SalesBoundedContext;
using Domain.Entities;

namespace BoundedContextExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            int customerId;
            decimal amount;

            using (var context = new ApplicationContext())
            {
                Invoice invoice = context.Invoices.First();
                id = invoice.Id;
                customerId = invoice.CustomerId;
                amount = invoice.Amount;
            }

            using (var context = new SalesContext())
            {
                Order order = context.Orders.First();
                Invoice invoice = order.Invoice;
                Console.WriteLine(invoice);
            }

            using (var context = new BillingContext())
            {
                InvoiceReference invoiceReference = context.Invoices.First();
                Console.WriteLine(invoiceReference);
                context.Invoices.Remove(invoiceReference);
                context.SaveChanges();
                var newInvoiceReference = new InvoiceReference
                {
                    Id = id,
                    CustomerId = customerId,
                    Amount = amount
                };
                context.Invoices.Add(newInvoiceReference);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
