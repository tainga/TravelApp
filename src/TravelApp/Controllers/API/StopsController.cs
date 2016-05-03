using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelApp.Models;
using Microsoft.Data.Entity;
using AutoMapper;
using TravelApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        private TripContext db;
        private CoordinateService cs;

        public StopsController(TripContext tp, CoordinateService service)
        {
            db = tp;
            cs = service;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public  JsonResult Get(string tripName)
        {
            var stops = db.Trips.Include(a => a.Stops).Where(a => a.Name == tripName);
            var results = Mapper.Map<IEnumerable<StopViewModel>>(stops);
            return Json(results);
        }

        // POST api/values
        [HttpPost]
        public async Task <JsonResult> Post(TripViewModel trip, StopViewModel stop)
        {
            var aTrip = Mapper.Map<Trip>(trip);
            var aStop = Mapper.Map<Stop>(stop);

            var longlat = await cs.Lookup(aStop.Name);
            if (longlat.Success)
            {
                aStop.Longitude = longlat.Longitude;
                aStop.Latitude = longlat.Latitude;
            }

            aTrip.Stops.Add(aStop);
            if (ModelState.IsValid)
            {
                db.Trips.Update(aTrip);
                db.SaveChanges();
            }

            
            var result = Mapper.Map<TripViewModel>(aTrip);
            return Json(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
