using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalebsSportsStore.Models;
using CalebsSportsStore.Models.ViewModels;

namespace CalebsSportsStore.Controllers
{
    //Can apply route attributes to the controllers themselves and remove the "Home" from the action attribute routes below
    //[Route("Home")]
    //[Route("[controller]")] <---if you change the controller in the future, you dont need to change this
    //[Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //This is how attribute routing works
        //[Route("~/")] <-- this supercedes the controller route attribute
        //[Route("[action]")]
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        //[Route("Home/Index/{id?}")]
        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,

                    //This returns the total items in databse no matter what category is selected
                    //TotalItems = repository.Products.Count()

                    //This determines how many total items are in the selected category
                    TotalItems = category == null ?
                        //TotalItems equals this if category == null
                        repository.Products.Count() :
                        //TotalItems equals this id category != null
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });

        //Ch. 8 Final Code
        //public ViewResult List(int productPage = 1)
        //    => View(new ProductsListViewModel
        //    {
        //        Products = repository.Products
        //            .OrderBy(p => p.ProductID)
        //            .Skip((productPage - 1) * PageSize)
        //            .Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //             CurrentPage = productPage,
        //             ItemsPerPage = PageSize,
        //             TotalItems = repository.Products.Count()
        //        }
        //    });

        //public ViewResult List() => View(repository.Products);

        //public ViewResult List(int productPage = 1)
        //    => View(repository.Products.OrderBy(p => p.ProductID)
        //        .Skip((productPage - 1) * PageSize).Take(PageSize));
    }
}
