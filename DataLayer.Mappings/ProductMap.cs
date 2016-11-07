﻿using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundedContext]
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
        }
    }
}