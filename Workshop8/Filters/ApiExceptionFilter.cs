using M7CarManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop8.Filters
{
    public class ApiExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ArgumentException ex)
            {
                context.ExceptionHandled = true;
                context.Result = new BadRequestObjectResult(new ErrorModel()
                {
                    Message = ex.Message,
                    Date = DateTime.Now
                });
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
