using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mime;

namespace CRUDExample.Filters.AuthorizationFilters
{
    public class TokenAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Request.Cookies.ContainsKey("Auth-Key") == false) // ("Auth-key") == "value of cookie") "somevalue of cookie")
            {
                // shortciruit filter
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }
            if (context.HttpContext.Request.Cookies["Auth-Key"] != "somevalidvalue") // ("Auth-key") == "value of cookie") "somevalue of cookie")
            {
                // shortciruit filter
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            //       throw new NotImplementedException();
        }
    }
}
