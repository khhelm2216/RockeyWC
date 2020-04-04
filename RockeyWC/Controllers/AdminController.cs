using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RockeyWC.Controllers
{
    public class AdminController : Controller
    {
        //private IProductRepository repository;

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Edit()
        {
            return View();
        }

        //Stubbed action methods

        /*[HttpPost]
        public IActionResult Edit()
        {
            return View();
        }

        //For creating products, orders, and rentals
        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            //action statement for deleting item, to be implemented in products, orders, and rentals
        }
        */
    }
}
