using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AntFlight.Models.FlightMessages;
using AntFlight.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using AntFlight.Models;

namespace AntFlight.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        AntRepository _repo;
        public TestController (RoleManager<IdentityRole> roleManger,
                               UserManager<ApplicationUser> userManager,
                               ApplicationDbContext context)
        {
            _roleManager = roleManger;
            _userManager = userManager;
            _repo = new AntRepository (context);
        }

        public IActionResult Index ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBasicFlights ()
        {
            ViewBag.Countries = new SelectList(_repo.Countries , "Id" , "Name");
            ViewBag.Subfamilies = new SelectList(_repo.Subfamilies , "Id" , "SubfamilieName");
            CreateFlightMessageDesciptionLists(new FlightMessageDescription());
            return View();
        }

        [HttpPost]
        public IActionResult AddBasicFlights (FlightMessage FmSample  ,int Count , DateTime End  )
        {
            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int DaysRage = (End - FmSample.FlightTime).Days;

                City[] Cities = _repo.Cities.ToArray(); 

                var UserId = _userManager.GetUserId(User);

                for (int i = 0 ; i < Count ; i++)
                {
                    string speciesname = _repo.Ants.FirstOrDefault(a => a.Id.Equals(FmSample.AntId)).SpeciesName;
                    DateTime flightTime = FmSample.FlightTime.AddDays(rand.Next(DaysRage));
                    var MessageTime = DateTime.Now;
                    _repo.AddFlight(new FlightMessage
                    {
                        AntId = FmSample.AntId ,
                        CityId = Cities[rand.Next(Cities.Count())].Id ,
                        FlightTime = flightTime.AddYears(-rand.Next(5)) ,
                        UserId = UserId ,
                        MessageTime = MessageTime ,
                        FMDescription = new FlightMessageDescription
                        {
                            Description = "Description" + i + " Generated FM of " + speciesname + " " ,
                            FlightIntensity = FmSample.FMDescription.FlightIntensity , 
                            Precipitation = FmSample.FMDescription.Precipitation ,
                            Sky = FmSample.FMDescription.Sky ,
                            Temperature = FmSample.FMDescription.Temperature ,
                            Terrain = FmSample.FMDescription.Terrain ,
                            Wind = FmSample.FMDescription.Wind
                        }
                    });
                }

                return Redirect("/Home");

            }
            else
            {
                
                return View(FmSample);
            }
            
        }


        private void CreateSpeciesSelectViewBag (FlightMessage message)
        {
            SelectList subfamilies;
            SelectList genuses;
            SelectList specieses;

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
        }
        private void CreateLocationSelectViewBag (FlightMessage message)
        {

            SelectList countries;
            SelectList cities;

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



    }
}