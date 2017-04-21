using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using AntFlight.Data;
using AntFlight.Models;
using Microsoft.EntityFrameworkCore;
using AntFlight.Models.Ants;
using AntFlight.Models.FlightMessages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace AntFlight.Controllers
{
    [Authorize]
    public class FlightMessagesController : Controller
    {
        AntRepository _repo;
        UserManager<ApplicationUser> _userManager;
        int LinesPerPage = 12;

        public FlightMessagesController (ApplicationDbContext context ,
                                           UserManager<ApplicationUser> manager)
        {
            _repo = new AntRepository(context);
            _userManager = manager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index ()
        {
            ViewBag.Countries = new SelectList(_repo.Countries , "Id" , "Name");
            ViewBag.Subfamilies = new SelectList(_repo.Subfamilies , "Id" , "SubfamilieName");
            return View(_repo.FlightMessageViewShort
                             .OrderByDescending(f => f.FlightTime)
                             .Take(12)
                             .ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Message (int id)
        {
            return View(_repo.GetFullFlightMessages
                            .FirstOrDefault(f => f.Id.Equals(id)));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Timetable ()
        {
            IQueryable<Ant> ants = _repo.AntsWithFlights;
            Queue<FlightTimetableLine> Timetable = new Queue<FlightTimetableLine>();
            return View(_repo.Ants.ToList());
        }

        [HttpGet]
        public IActionResult AddFlight ()
        {
            ViewBag.Countries = new SelectList(_repo.Countries , "Id" , "Name");
            ViewBag.Subfamilies = new SelectList(_repo.Subfamilies , "Id" , "SubfamilieName");
            CreateFlightMessageDesciptionLists(new FlightMessageDescription());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFlight (FlightMessage message)
        {
            if (ModelState.IsValid)
            {
                message.UserId = _userManager.GetUserId(User);
                message.MessageTime = DateTime.Now;
                _repo.AddFlight(message);
                return Redirect("/Home");
            }
            else
            {
                SelectList subfamilies;
                SelectList genuses;
                SelectList specieses;
                SelectList countries;
                SelectList cities;


                subfamilies = new SelectList(_repo.Subfamilies , "Id" , "SubfamilieName");
                if (message.Ant.Genus.SubfamilieId > 0)
                {
                    subfamilies.First(s => s.Value.Equals(message.Ant.Genus.SubfamilieId.ToString())).Selected = true;

                    genuses = new SelectList(_repo.Genuses.Where(g => g.SubfamilieId.Equals(message.Ant.Genus.SubfamilieId)) , "Id" , "GenusName");
                    if (message.Ant.GenusId > 0)
                    {
                        genuses.First(s => s.Value.Equals(message.Ant.GenusId.ToString())).Selected = true;

                        specieses = new SelectList(_repo.Ants.Where(g => g.GenusId.Equals(message.Ant.GenusId)) , "Id" , "SpeciesName");
                        if (message.AntId > 0)
                        {
                            
                            specieses.First(s => s.Value.Equals(message.AntId.ToString())).Selected = true;
                        }
                        ViewBag.Specieses = specieses;
                    }
                    ViewBag.Genuses = genuses;
                }
                ViewBag.Subfamilies = subfamilies;

                countries = new SelectList(_repo.Countries , "Id" , "Name");
                if (message.City.CountryId > 0)
                {
                    countries.First(c => c.Value.Equals(message.City.CountryId.ToString())).Selected = true;

                    cities = new SelectList(_repo.Cities , "Id" , "Name");
                    if (message.CityId > 0)
                    {
                        cities.First(c => c.Value.Equals(message.CityId.ToString())).Selected = true;
                    }
                    ViewBag.Cities = cities;
                }
                ViewBag.Countries = countries;



                CreateFlightMessageDesciptionLists(message.FMDescription);
                return View(message);
            }
        }

        private void CreateFlightMessageDesciptionLists (FlightMessageDescription description)
        {
            ViewBag.FlightIntensity = FlightMessageDescription.GetSelectList(description.FlightIntensity , FlightMessageDescription.GetFlightIntensityArr);
            ViewBag.Temperature = FlightMessageDescription.GetSelectList(description.Temperature , FlightMessageDescription.GetTemperatureArr);
            ViewBag.Precipitation = FlightMessageDescription.GetSelectList(description.Precipitation , FlightMessageDescription.GetPrecipitationArr);
            ViewBag.Sky = FlightMessageDescription.GetSelectList(description.Sky , FlightMessageDescription.GetSkyArr);
            ViewBag.Wind = FlightMessageDescription.GetSelectList(description.Wind , FlightMessageDescription.GetWindArr);
            ViewBag.Terrain = FlightMessageDescription.GetSelectList(description.Terrain , FlightMessageDescription.GetTerrainArr);
        }

        #region JsonResults

        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public JsonResult GetMoreFlights (int loaded)
        {
            return Json(_repo.FlightMessageViewShort
                              .OrderByDescending(f => f.FlightTime)
                              .Skip(loaded)
                              .Take(LinesPerPage)
                              .ToList());
        }
        #endregion
        #region JsonFilters
        [HttpPost]
        [AllowAnonymous]
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
        
        
        [AllowAnonymous]
        public JsonResult SubfamilieFilter (int subfamilieId)
        {
            return Json(_repo.Genuses
                            .Where(g => g.SubfamilieId.Equals(subfamilieId))
                            .ToList());
        }
        [AllowAnonymous]
        public JsonResult GenusFilter (int genusId)
        {
            return Json(_repo.Ants
                            .Where(a => a.GenusId.Equals(genusId))
                            .ToList());
        }
        [AllowAnonymous]
        public JsonResult CountryFilter (int countryId)
        {
            return Json(_repo.Cities
                            .Where(c => c.CountryId.Equals(countryId))
                            .ToList());
        }
        #endregion
    }
}