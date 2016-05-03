using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TravelApp.Models;
using Microsoft.Data.Entity;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelApp.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        private TripContext db = new TripContext();
        
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
        public JsonResult Post(TripViewModel trip, StopViewModel stop)
        {
            var aTrip = Mapper.Map<Trip>(trip);
            var aStop = Mapper.Map<Stop>(stop);
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
