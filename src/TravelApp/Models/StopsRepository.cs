using AutoMapper;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public class StopsRepository
    {
        private TripContext db;

        public StopsRepository(TripContext context)
        {
            db = context;
        }

        //public IEnumerable<Stop> GetAllTrips()
        //{
        //    var stops = db.Stops;
        //    return stops;
        //}

        public IEnumerable<Stop> Get(string tripName)
        {
            var trip = db.Trips.Include(a => a.Stops).Where(a => a.Name == tripName).Single();
            return trip.Stops;
        }

        public Trip Post(Trip trip, Stop stop)
        {
            trip.Stops.Add(stop);
            db.Trips.Update(trip);
            db.SaveChanges();

            return trip;
            
        }
    }
}
