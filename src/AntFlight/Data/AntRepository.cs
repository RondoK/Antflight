using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AntFlight.Models;
using AntFlight.Models.Ants;
using AntFlight.Models.FlightMessages;
using Microsoft.EntityFrameworkCore;

namespace AntFlight.Data
{
    public class AntRepository
    {
        ApplicationDbContext db;

        public IQueryable<City> Cities
        {
            get
            {
                return db.Cities;
            }
        }

        public IQueryable<Country> Countries
        {
            get
            {
                return db.Countries;
            }
        }

        public IQueryable<Subfamilie> Subfamilies
        {
            get
            {
                return db.Subfamilies;
            }
        }

        public IQueryable<Genus> Genuses
        {
            get
            {
                return db.Genuses;
            }
        }

        public IQueryable<OriginalFlightTime> OriginalFlight
        {
            get
            {
                return db.OriginalFlightTime;
            }
        }


        public IQueryable<Ant> Ants
        {
            get
            {
                return db.Ants;
            }
        }

        public IQueryable<AntView> FullAnts
        {
            get
            {
                return from a in db.Ants
                       join gen in db.Genuses on a.GenusId equals gen.Id
                       join subfamilie in db.Subfamilies on gen.SubfamilieId equals subfamilie.Id
                       join subGen in db.Subgenuses on a.SubgenusId equals subGen.Id into sub
                       from subgen in sub.DefaultIfEmpty()
                       join origFlightT in db.OriginalFlightTime on a.Id equals origFlightT.AntId into origft
                       from OFlightTime in origft.DefaultIfEmpty()
                       select new AntView
                       {
                           Id = a.Id ,
                           Species = a.SpeciesName ,
                           Subgenus = subgen.SubgenusName ,
                           Genus = gen.GenusName ,
                           Subfamilie = subfamilie.SubfamilieName ,
                           OriginalFlightTime = OFlightTime
                       };
                ;
            }
        }

        public IQueryable<Ant> AntsWithFlights
        {
            get
            {
                return db.Ants
                    .Include(a => a.FlightMessages)
                    .OrderBy(a=>a.SpeciesName);
            }
        }



        public IQueryable<FlightMessage> FlightMessages
        {
            get
            {
                return db.FlightMessages;
            }
        }

        public IQueryable<FlightMessage> GetFullFlightMessages
        {
            get
            {
                return db.FlightMessages.Include(f => f.Ant)
                                        .Include(f => f.User)
                                        .Include(f => f.FMDescription)
                                        .Include(f => f.City)
                                            .ThenInclude(c => c.Country);
            }
        }

        public void AddFlight (FlightMessage message)
        {
                message.Ant = null;
                message.City = null;
                message.User = null;
            db.FlightMessages.Add(message);
            db.SaveChanges();
        }

        public IQueryable<FlightMessageViewShort> FlightMessagesToView (IQueryable<FlightMessage> FM)
        {
            return from fm in FM
                   select new FlightMessageViewShort
                   {
                       Id = fm.Id ,
                       Species = fm.Ant.SpeciesName ,
                       City = fm.City.Name ,
                       Country = fm.City.Country.Name ,
                       FlightTime = fm.FlightTime
                   };
        }

        public IQueryable<FlightMessageViewShort> FlightMessageViewShort
        {
            get
            {
                return from f in db.FlightMessages
                       join a in db.Ants on f.AntId equals a.Id
                       join city in db.Cities on f.CityId equals city.Id
                       join country in db.Countries on city.CountryId equals country.Id
                       select new FlightMessageViewShort
                       {
                           Id = f.Id ,
                           Species = a.SpeciesName ,
                           City = city.Name ,
                           Country = country.Name ,
                           FlightTime = f.FlightTime
                       };
            }
        }

        public AntRepository (ApplicationDbContext DB)
        {
            db = DB;
        }
    }
}
