using CRUDExample.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts.DTO;

namespace CRUDExample.Filters.ActionFilters
{
    public class PersonsListActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public PersonsListActionFilter(ILogger<PersonsListActionFilter> logger)
        {
            _logger = logger;
        }
        //here we are updating the search parameter of the action method to default as Person.PersonName
        // when somene tried to enter the search parameter which doesnot exists update the serachparameter to personname as default
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();

            _logger.LogInformation("PersonsListActionFilter -OnActionExecuting  ");

            context.HttpContext.Items["arguments"] = context.ActionArguments;
            
            //add code before the logic of action

            if (context.ActionArguments.ContainsKey("searchBy"))
            {
                string searchBy = Convert.ToString(context.ActionArguments["searchBy"]);

                if(!string.IsNullOrEmpty(searchBy))
                {
                    var searchByOptions = new List<string>()
                    {
                        nameof(PersonResponse.PersonName),
                        nameof(PersonResponse.Email),
                        nameof(PersonResponse.DateOfBirth),
                        nameof(PersonResponse.Gender),
                        nameof(PersonResponse.CountryID),
                        nameof(PersonResponse.Address)

                    };
                    if (searchByOptions.Any(x => x == searchBy) == false)
                    {
                        _logger.LogInformation("searchBy actual value {searchBy}", searchBy);
                        context.ActionArguments["searchBy"] =nameof(PersonResponse.PersonName);
                        _logger.LogInformation("searchBy updated value {searchBy}", searchBy);

                    }
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplemented                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           Exception();

            _logger.LogInformation("PersonsListActionFilter -OnActionExecuted ");

            //add code after the logic of action
            PersonsController personscontroler = (PersonsController) context.Controller;
            
            IDictionary<string,object>? parameters = (IDictionary<string,object>) context.HttpContext.Items["arguments"];

            if (parameters != null)
            {
                if (parameters.ContainsKey("searchBy"))
                {
                    personscontroler.ViewData["CurrentSearchBy"] = Convert.ToString(parameters["searchBy"]);
                }
                if (parameters.ContainsKey("searchString"))
                {
                    personscontroler.ViewData["CurrentSearchString"] = Convert.ToString(parameters["searchString"]);
                }
                if (parameters.ContainsKey("sortBy"))
                {
                    personscontroler.ViewData["CurrentSortBy"] = Convert.ToString(parameters["sortBy"]);
                }
                if (parameters.ContainsKey("sortOrder"))
                {
                    personscontroler.ViewData["CurrentSortOrder"] = Convert.ToString(parameters["sortOrder"]);
                }

            }
        }

    }
}
