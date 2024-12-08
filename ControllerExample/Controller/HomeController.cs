using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace ControllerExample
{
    public class HomeController : Controller
    {
        [Route("sayhellow")]               // Attribute routing
        [Route("/")]
        public string method1()
        {
            return "Hellow from Home controller";
        }

        [Route("about/{LandLine:int}")]
        public string about()
        {
            return "From About";
        }
        [Route("contact-us/{moblie:regex(^\\d{{10}}$)}")]
        public string contact()
        {
            return "From contact";
        }

        [Route("checkcontent")]
        public ContentResult checkcontentresult()
        {
            return Content("Context to be typed", "text/plain");

        }
        
        [Route("contentashtml")]
        public ContentResult htmlcontent()
        {

            // return content as html
            return Content("<h1>welcome </h1><h2>from html page </h2>", "text/html");

        }
       
        [Route("personjsondetails")]
        public JsonResult persondata()
        {
            Person p = new Person()
            {
                Id1 = System.Guid.NewGuid(),
                FirstName = "testFirstName",
                LastName = "testLastName",
                Age = 50
            };
             return new JsonResult(p);
        }


        // File Results
        // 3 types
        // VirutualFileResult   PhysicalFileResult        FileContentResult
        [Route("virtualfiledownload")]
        public  VirtualFileResult filedownload1()
        {
            return new VirtualFileResult("KukkiSubramanyaSwamyTicketBooking.pdf","application/pdf");
        }

        [Route("physicaldownload")]
        public PhysicalFileResult filedownload2()
        {
            return new PhysicalFileResult(@"C:\Users\Mahendra\source\repos\ControllerExample\ControllerExample\crackersinvoice.jpg", "image/jpg");
        }
        [Route("filecontentresult")]
        public FileContentResult filedownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Mahendra\source\repos\ControllerExample\ControllerExample\saificoresume.pdf");
            return new FileContentResult(bytes,"application/pdf");
        }

        [Route("ActionResultsTest")]
        public IActionResult testactionresult()
        {
            if (!Request.Query.ContainsKey("bookid"))
                {
                return BadRequest("bookid doesnot existing");
              }

            return File(@"saificoresume.pdf", "application/pdf");                

        }

        [Route("RedirectResult1")]
        public IActionResult RedirectResult1()
        {
            return new RedirectToActionResult("bookstore", "Store", new { });
        }
        
    }
}
