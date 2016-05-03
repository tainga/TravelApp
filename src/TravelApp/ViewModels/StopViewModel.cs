using System;
using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class StopViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Stop name is required")]
        [StringLength(255, ErrorMessage = "Trip name cannot be too short or too long.", MinimumLength = 5)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Arrival date is required")]
        public DateTime Arrival { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}