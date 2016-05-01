using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TravelApp.Models
{
    public class TripContext : dbContext
    {

        //public TripContext() : base("name=travelContext")
        //{
        //}

        public System.Data.Entity.DbSet<TravelApp.Models.Trip> Trips { get; set; }

        public System.Data.Entity.DbSet<TravelApp.Models.Stop> Stops { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
