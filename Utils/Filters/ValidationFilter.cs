using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Login.Utils.Filters
{
    /// <summary>
    /// Filters the errors from the generic error that we got from invalid
    /// ModelState and maps it to a ModelErrorResponse
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
        )
        {
            //before controller
            if (!context.ModelState.IsValid)
            {
                // Only show one error message at a time.
                var firstError = context.ModelState.FirstOrDefault().Value.Errors.FirstOrDefault();

                context.Result = new BadRequestObjectResult(firstError.ErrorMessage);
                return;
            }
            await next();

            //after controller
        }
    }
}
