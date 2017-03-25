using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AntFlight.Data;
using AntFlight.Models;
using Microsoft.EntityFrameworkCore;
using AntFlight.Models.Ants;
using AntFlight.Models.FlightMessages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AntFlight.Controllers
{
    public class FlightMessagesController : Controller
    {
        AntRepository _repo;
        int LinesPerPage = 12;

        public FlightMessagesController (ApplicationDbContext context)
        {
            _repo = new AntRepository(context);
        }

        [HttpGet]
        public IActionResult Index (int id)
        {
            ViewBag.Countries = new SelectList(_repo.Countries , "Id" , "Name");
            ViewBag.Subfamilies = new SelectList(_repo.Subfamilies , "Id" , "SubfamilieName");
            return View(_repo.FlightMessagesView
                             .OrderByDescending(f => f.FlightTime)
                             .Take(12)
                             .ToList());
        }

        public IActionResult Message (int id)
        {
            return View(_repo.GetFlightMessage
                            .FirstOrDefault(f => f.Id.Equals(id)));
        }

        [HttpGet]
        public IActionResult Timetable ()
        {
            IQueryable<Ant> ants = _repo.AntsWithFlights;
            Queue<FlightTimetableLine> Timetable = new Queue<FlightTimetableLine>();
            return View(_repo.Ants.ToList());
        }





        public JsonResult FlightsTimetableJson ()
        {
            Queue<FlightTimetableLine> timeTable = new Queue<FlightTimetableLine>();
            var ants = _repo.AntsWithFlights;
            foreach (var ant in ants)
            {
                FlightTimetableLine timeline = new FlightTimetableLine(ant.SpeciesName , 4);
                foreach (var message in ant.FlightMessages.OrderBy(f => f.FlightTime))
                {
                    if (message.FlightTime.Month == 1)
                    { continue; }
                    int day = message.FlightTime.Day;
                    if (day < 9)
                    {
                        timeline.Months[message.FlightTime.Month - 2 , 0]++;
                        continue;
                    }
                    else
                    {
                        if (day < 17)
                        {
                            timeline.Months[message.FlightTime.Month - 2 , 1]++;
                        }
                        else
                        {
                            if (day < 24)
                            {
                                timeline.Months[message.FlightTime.Month - 2 , 2]++;
                            }
                            else
                            {
                                timeline.Months[message.FlightTime.Month - 2 , 3]++;
                            }
                        }
                    }
                }
                timeTable.Enqueue(timeline);
            }
            return Json(timeTable);
        }

        [HttpPost]
        public JsonResult GetMoreFlights (int loaded)
        {
            return Json(_repo.FlightMessagesView
                              .OrderByDescending(f => f.FlightTime)
                              .Skip(loaded)
                              .Take(LinesPerPage)
                              .ToList());
        }

        [HttpPost]
        public JsonResult GetFilteredFlights (int loaded , int subfamilieId , int genusId , int speciesId ,
                                                    int countryId , int cityId)
        {
            IQueryable<FlightMessage> FRequest = _repo.FlightMessages;
            if (speciesId != 0)
            {
                FRequest = FRequest.Where(f => f.AntId.Equals(speciesId));
            }
            else
            {
                if (genusId != 0)
                {
                    FRequest = FRequest.Where(f => f.Ant.GenusId.Equals(genusId));
                }
                else
                {
                    if (subfamilieId != 0)
                    {
                        FRequest = FRequest.Where(f => f.Ant.Genus.SubfamilieId.Equals(subfamilieId));
                    }
                }
            }

            if (cityId != 0)
            {
                FRequest = FRequest.Where(f => f.CityId.Equals(cityId));
            }
            else
            {
                if (countryId != 0)
                {
                    FRequest = FRequest.Where(f => f.City.CountryId.Equals(countryId));
                }
            }

            return Json(_repo.FlightMessagesToView(FRequest)
                              .OrderByDescending(f => f.FlightTime)
                              .Skip(loaded)
                              .Take(LinesPerPage)
                              .ToList());
        }

        public JsonResult SubfamilieFilter (int subfamilieId)
        {
            return Json(_repo.Genuses
                            .Where(g => g.SubfamilieId.Equals(subfamilieId))
                            .ToList());
        }
        public JsonResult GenusFilter (int genusId)
        {
            return Json(_repo.Ants
                            .Where(a => a.GenusId.Equals(genusId))
                            .ToList());
        }

        public JsonResult CountryFilter (int countryId)
        {
            return Json(_repo.Cities
                            .Where(c => c.CountryId.Equals(countryId))
                            .ToList());
        }
    }
}