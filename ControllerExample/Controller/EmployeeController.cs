using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ControllerExample
{
    public class EmployeeController : Controller
    {
        [Route("Registration")]
        public IActionResult AddEmployee(Employee employee)
        {
            List<string> errorlist = new List<string>();
            if (!ModelState.IsValid) 
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorlist.Add(error.ErrorMessage);
                    }
                }
                var errors = string.Join("\n", errorlist);
                return Json(errors);

            }

            return Json(employee);
        }
    }
}
