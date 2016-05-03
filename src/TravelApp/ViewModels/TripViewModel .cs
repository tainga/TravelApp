using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class TripViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Trip name is required")]
        [StringLength(255, ErrorMessage = "Trip name cannot be too short or too long.", MinimumLength = 5)]
        public string Name { get; set; }
        public DateTime CreatedDate = DateTime.Now;
        public ICollection<StopViewModel> Stops { get; set; }
    }
}