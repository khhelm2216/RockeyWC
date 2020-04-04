using RockeyWC.Database;
using RockeyWC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RockeyWC.FilterLibrary
{
    // Here is our action log attribute that
    public class ActionLogAttribute : ActionFilterAttribute //, IActionFilter
    {
        // Filter activated just before the action occurs
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the controller and pull out the action information
            Controller myController = (Controller)context.Controller;

            ActionLog log = new ActionLog()
            {
                Controller = myController.ToString(),
                Action = myController.ControllerContext.ActionDescriptor.ActionName,
                HttpMethod = myController.HttpContext.Request.Method,
                ActionDate = DateTime.Now,
                URL = myController.HttpContext.Request.Path

            };

            // save the action log - Attributes don't work with Dependency Injection
            FakeActionLogRepository repository = new FakeActionLogRepository();
            repository.SaveLogAction(log);
        }
    }
}