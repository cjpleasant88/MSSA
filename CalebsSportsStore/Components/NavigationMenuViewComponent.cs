using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CalebsSportsStore.Models;

namespace CalebsSportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            //Stores Seleted Category from Category Navigation Menu
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
        //Original Test Mehtod
        //public string Invoke()
        //{
        //    return "Hello from the Nav View Component";
        //}
    }
}
