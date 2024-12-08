using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace ControllerExample
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //RouteParam  
        //http://localhost:5136/book/store/15/test1          input as routeparam
        [Route("book/store/{bookid}/{authorname}")]
        public IActionResult bookstoreRouteparam(int bookid, string authorname)
        {
            //   return View();
            return Content("<html><h1>from Stroecontroller bookstroe action method</h1></html>");
        }


        //Query string 
        //input as query string
//        http://localhost:5136/bookquerystring/store?bookid=5&authorname=test   input as query string
        [Route("bookquerystring/store")]
        public IActionResult bookstoreQuerystrint(int bookid, string authorname)
        {
            //   return View();
            return Content("<html><h1>from Stroecontroller bookstroe action method</h1></html>");
        }


        //passing the Route Param aswell as QueryString 
        //input as query string  as bookid
        // passing bookdid as param and authorname as query string
        //       http://localhost:5136/bookquerystringorrouteparam/store/5?authorname=test   input as query string
        [Route("bookquerystringorrouteparam/store/{bookid}")]
        public IActionResult bookquerystringorrouteparam(int bookid, string authorname)
        {
            //   return View();
            return Content("<html><h1>from Stroecontroller bookstroe action method</h1></html>");
        }



       //passing the Route Param aswell as Querystring
       // input query string as authorname
      //  http://localhost:5136/bookquerystringvsrouteparam/store/test?bookid=5
        [Route("bookquerystringvsrouteparam/store/{authorname}")]
        public IActionResult bookquerystringvsrouteparam(int bookid, string authorname)
        {
            //   return View();
            return Content("<html><h1>from Stroecontroller bookstroe action method</h1></html>");
        }


        //passing the Route Param aswell as Querystring and prioritise based on FromBody/FromRoute
        // input query string as authorname
        // the below url passes values as query stiring but for the bookid the value is null
        // because we mentioned to accept values FromRoute
        //  http://localhost:5136/bookquerystringandrouteparam/store?bookid=5&authorname=testauthor
        // Here the value i get is only from authorname = test but bookid =0
        // //becuase we mentioned to accept value from FromRoute

        [Route("bookquerystringandrouteparam/store")]
        public IActionResult bookquerystringandrouteparam([FromRoute]int bookid,[FromQuery] string authorname)
        {
            //   return View();
            return Content("<html><h1>from Stroecontroller bookstroe action method</h1></html>");
        }


        //This method will pass entier Person model as Query Param and if we want only one or two
        // attributes to specifically then in the model we can specify the particular property as FROMROUTE

        //In the Person model mentioned as
        // [FromRoute]
       // public string FirstName { get; set; }

        //  mentioned as Query Param
        [Route("adduser")]
        public IActionResult addperson(Person person)
        {
             
        return Json(person); 
        }
    }
}
