using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        //Pg 124
        public IActionResult Index()
        {
            Product[] array =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifjacket", Price = 48.95M},
                new Product {Name = "Soccer Ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M},
            };
            return View(array);
        }
        ////Start up to pag 124
        //public ViewResult Index()
        //{
        //    Product myProduct = new Product
        //    {
        //        ProductID = 1,
        //        Name = "Kayak",
        //        Description = "A boat for one person",
        //        Category = "Watersports",
        //        Price = 275M
        //    };

        //    ViewBag.StockLevel = 2;

        //    return View(myProduct);
        //}
    }
}
