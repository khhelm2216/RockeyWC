using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace RockeyWC.FilterLibrary
{
    // Used for filter demonstrations - not in current use
    public class ViewResultDiagnostics : IActionFilter
    {
        private IFilterDiagnostics diagnostics;

        public ViewResultDiagnostics(IFilterDiagnostics DI_diagnostics)
        {
            diagnostics = DI_diagnostics;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do nothing - not used in this filter
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult responseViewResult;
            if ((responseViewResult = context.Result as ViewResult) != null)
            {
                var name = responseViewResult.ViewName ?? "Null";
                diagnostics.AddMessage($"View name: {name}");

                var result = responseViewResult.ViewData?.Model?.GetType().Name ?? "Null";
                diagnostics.AddMessage($@"Model type: {result}");
            }
        }
    }
}
