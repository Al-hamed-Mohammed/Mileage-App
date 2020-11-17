using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MileageApp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Travel Date")]
        [DataType(DataType.Date)]
        public DateTime TravelDate { get; set; }
        public string Client { get; set; }

        [Display(Name = "Starting Point to Destination")]
        public string StartToEnd { get; set; }
        public double Miles { get; set; }
    }
}
