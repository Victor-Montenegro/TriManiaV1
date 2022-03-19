using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace TriMania_V1.Filters
{
    public class ErrorsValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(sm => sm.Errors).Select(e => e.ErrorMessage));
        }
    }
}
