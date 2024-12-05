using Microsoft.AspNetCore.Mvc;
using System;

namespace ControllerExample.Models
{

    public class Person
    {
        public Guid Id1 { get; set; }
        public int Id { get; set; }


        //     [FromRoute]        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }

   
}
