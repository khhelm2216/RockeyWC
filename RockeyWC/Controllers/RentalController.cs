using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RockeyWC.Controllers
{
    //Being used, but not working yet. Need authorizaiton for inventory/rental management specific people
    public class RentalController : Controller
    {
        // GET: /<controller>/
        public ViewResult List()
        {
            return View();
        }
    }
}
