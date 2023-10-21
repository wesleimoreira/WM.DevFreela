using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WM.DevFreela.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage)).ToList();

                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
