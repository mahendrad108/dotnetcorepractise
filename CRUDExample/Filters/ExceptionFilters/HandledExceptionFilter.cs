using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ExceptionFilters
{
    public class HandledExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HandledExceptionFilter> _logger;
        private readonly IHostEnvironment _hostenvironment;
        public HandledExceptionFilter(ILogger<HandledExceptionFilter> logger, IHostEnvironment hostenvironment)
        {
            _logger = logger;
            _hostenvironment = hostenvironment; 
        }
        public void OnException(ExceptionContext context)
        {
          _logger.LogError("Exception Filter {FilterName}.{MethodName} \n {ExceptionType} \n {ExceptionMessage}",
              nameof(HandledExceptionFilter),nameof(OnException),context.Exception.GetType().ToString(),
              context.Exception.Message);

            if (_hostenvironment.IsDevelopment())
            {
                context.Result = new ContentResult()
                {
                    Content = context.Exception.Message,
                    StatusCode = 500
                };
            }
        }
    }
}
