using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class Trip
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserName { get; set; }
        public ICollection<Stop> Stops { get; set; }
    }
}
