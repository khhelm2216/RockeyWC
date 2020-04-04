using RockeyWC.FilterLibrary;
using Microsoft.AspNetCore.Mvc;

namespace RockeyWC.Controllers
{
    // This controller is just here to show Global Filters and for you t0
    // change the order number to change their activation order
    [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class GlobalController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]
        public ViewResult Index() => View("Message", "This is the global controller");
    }
}