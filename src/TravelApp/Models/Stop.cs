using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class Stop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Arrival { get; set; }
        public int Order { get; set; }
    }
}
