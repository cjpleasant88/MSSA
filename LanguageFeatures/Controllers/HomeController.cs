using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {

        //public ViewResult Index()
        //{
            ////*****pg 103-104
            //var products = new[]
            //{
            //    new { Name = "Kayak", Price = 275M },
            //    new { Name = "Lifejacket", Price = 48.95M },
            //    new { Name = "Soccer Ball", Price = 19.50M },
            //    new { Name = "Corner flag", Price = 34.95M }
            //};
            //return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));

            //*****pg 102
            public async Task<ViewResult> Index()
            {
                long? length = await MyAsyncMethods.GetPageLength();
                return View(new string[] { $"Length: {length}" });

                //public ViewResult Index()
                //{
                //    //*****pg 97-98 part 2
                //    var products = new[]
                //    {
                //        new { Name = "Kayak", Price = 275M },
                //        new { Name = "Lifejacket", Price = 48.95M },
                //        new { Name = "Soccer Ball", Price = 19.50M },
                //        new { Name = "Corner flag", Price = 34.95M }
                //    };
                //    return View(products.Select(p => p.GetType().Name));

                ////*****pg 97
                //var names = new[] { "Kayak", "Lifejacket", "Soccer Ball" };
                //return View(names);


                ////*****pg 92
                //bool FilterByPrice(Product p)
                //{
                //    return (p?.Price ?? 0) >= 20;
                //}
                ////*****pg 95 part 2
                //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));

                //public ViewResult Index()
                //{
                ////*****pg 95
                //return View(Product.GetProducts().Select(p => p?.Name));

                ////*****pg 93

                //Product[] productArray =
                //{
                //    new Product {Name = "Kayak", Price = 275M},
                //    new Product{ Name = "Lifejacket", Price = 48.95M },
                //    new Product{ Name = "Soccer Ball", Price = 19.50M },
                //    new Product{ Name = "Corner flag", Price = 34.95M }
                //};

                //Func<Product, bool> nameFilter = delegate (Product prod)
                //{
                //    return prod?.Name?[0] == 'S';
                //};

                //decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
                //decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();

                ////decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
                ////decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

                //return View("Index", new string[]
                //{
                //    //$"Total: {cartTotal:c2}",
                //    $"Price Total: {priceFilterTotal:c2}",
                //    $"Name Total: {nameFilterTotal:c2}"
                //});

                ////*****pg 89
                //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

                //Product[] productArray =
                //{
                //    new Product {Name = "Kayak", Price = 275M},
                //    new Product{ Name = "Lifejacket", Price = 48.95M },
                //    new Product{ Name = "Soccer Ball", Price = 19.50M },
                //    new Product{ Name = "Corner flag", Price = 34.95M }
                //};

                ////decimal cartTotal = cart.TotalPrices();
                //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();


                //return View("Index", new string[]
                //{
                //    //$"Total: {cartTotal:c2}",
                //    $"Array Total: {arrayTotal:c2}"
                //});

                ////*****pg 86
                //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
                //decimal cartTotal = cart.TotalPrices();
                //return View("Index", new string[] { $"Total: {cartTotal:c2}" });

                ////*****pg 84 -85
                //object[] data = new object[]
                //{
                //    275M, 29.95M, "apple", "orange", 100, 10
                //};
                //decimal total = 0;
                //for (int i = 0; i < data.Length; i++)
                //{
                //    switch (data[i])
                //    {
                //        case decimal decimalValue:
                //            total += decimalValue;
                //            break;
                //        case int intValue when intValue > 50:
                //            total += intValue;
                //            break;
                //    }
                //    //if (data[i] is decimal d)
                //    //{
                //    //    total += d;
                //    //}
                //}
                //return View("Index", new string[] { $"Total: {total:c2}" });

                ////*****pg 83
                //Dictionary<string, Product> products = new Dictionary<string, Product>
                //{
                //    ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                //    ["Lifejacket"] = new Product{ Name = "Lifejacket", Price = 48.95M }
                //};
                //return View("Index", products.Keys);

                ////*****pg 82
                //Dictionary<string, Product> products = new Dictionary<string, Product>
                //{
                //    { "Kayak", new Product { Name = "Kayak", Price = 275M } },
                //    { "Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M } }
                //};
                //return View("Index", products.Keys);

                ////*****pg 81 
                //return View("Index", new string[] { "Bob", "Joe", "Alice" });


                ////*****pg 67 - 80
                //List<string> results = new List<string>();

                //foreach (Product p in Product.GetProducts())
                //{

                //    string name = p?.Name ?? "<No Name>";
                //    decimal? price = p?.Price ?? 0;
                //    string relatedName = p?.Related?.Name ?? "<None>";

                //    results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
                //}
                //return View(results);
            }
}
}
