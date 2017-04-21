using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AntFlight.Models;

using AntFlight.Models.Ants;
using AntFlight.Models.FlightMessages;

namespace AntFlight.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Subfamilie> Subfamilies { get; set; }
        public DbSet<Genus> Genuses { get; set; }
        public DbSet<Subgenus> Subgenuses { get; set; }
        public DbSet<Ant> Ants { get; set; }
        public DbSet<OriginalFlightTime> OriginalFlightTime { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FlightMessage> FlightMessages { get; set; }
        public DbSet<FlightMessageDescription> FlightMessagesDescr { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
