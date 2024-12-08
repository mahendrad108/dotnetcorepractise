using System.ComponentModel.DataAnnotations;

namespace ControllerExample.Models
{
    public class Employee
    {
        [Required]
        public int emplid { get; set; }
        
        public string? empname { get; set; }
        public string department { get; set; }

        public string city { get; set; }

        public int salary { get; set; }
    }
}
