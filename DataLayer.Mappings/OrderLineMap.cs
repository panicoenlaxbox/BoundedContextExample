﻿using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace DataLayer.Mappings
{
    [SalesBoundedContext]
    public class OrderLineMap : EntityTypeConfiguration<OrderLine>
    {
        public OrderLineMap()
        {
        }
    }
}