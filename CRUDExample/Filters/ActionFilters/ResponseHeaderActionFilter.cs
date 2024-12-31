using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : IActionFilter,IOrderedFilter
    {
        private readonly ILogger<ResponseHeaderActionFilter> _logger;
        private readonly string Key;
        private readonly string Value;

        public int Order { get; set; }

        public ResponseHeaderActionFilter(ILogger<ResponseHeaderActionFilter> logger,string key,string value,int order)  
        {
            _logger = logger;
            Key = key;
            Value = value;
            Order = order;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("In ResponseHeaderActionFilter - OnActionExecuting");

         //   throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("In ResponseHeaderActionFilter - OnActionExecuted");

             context.HttpContext.Response.Headers[Key] = Value;

          //  throw new NotImplementedException();
        }

    }
}
