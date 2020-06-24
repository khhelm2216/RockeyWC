using RockeyWC.Database;
using RockeyWC.FilterLibrary;
using RockeyWC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace RockeyWC.Controllers
{
    public class HomeController : Controller
    {
        // Constructor and repository
        private IActionLogRepository repository;
        public HomeController(IActionLogRepository DI_Repository)
        {
            repository = DI_Repository;
        }

        [ActionLog]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActionLogs()
        {
            var actionLogs = (from a in repository.LogListing select a).ToList();
            return View(actionLogs);
        }

        public ActionResult ClearLogs()
        {
            repository.DeleteAllLogActions();
            var actionLogs = (from a in repository.LogListing select a).ToList();
            return RedirectToAction("ActionLogs");
        }

        [ActionLog]
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your privacy page.";

            return View();
        }

        public FileContentResult UserGuide()
        {
            var bytes = System.IO.File.ReadAllBytes("wwwroot/images/PeabodyGuide.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
