﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalebsSportsStore.Models;
using CalebsSportsStore.Models.ViewModels;

namespace CalebsSportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                     CurrentPage = productPage,
                     ItemsPerPage = PageSize,
                     TotalItems = repository.Products.Count()
                }
            });

        //public ViewResult List() => View(repository.Products);

        //public ViewResult List(int productPage = 1)
        //    => View(repository.Products.OrderBy(p => p.ProductID)
        //        .Skip((productPage - 1) * PageSize).Take(PageSize));
    }
}
