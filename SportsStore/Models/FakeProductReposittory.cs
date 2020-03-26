﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductReposittory : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf Board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        }.AsQueryable<Product>();
    }
}
