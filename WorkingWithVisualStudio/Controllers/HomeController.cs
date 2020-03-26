using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index() => View(SimpleRepository.SharedRepository.Products.Where(p => p?.Price < 50));
        //SimpleRepository Repository = SimpleRepository.SharedRepository;

        public IRepository Repository = SimpleRepository.SharedRepository;

        //public IActionResult Index() => View(Repository.Products.Where(p => p?.Price < 100));
        public IActionResult Index() => View(Repository.Products);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}
