using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AntFlight.Data;

using AntFlight.Models;
using AntFlight.Models.Ants;
using AntFlight.Models.FlightMessages;
using Newtonsoft.Json;

namespace AntFlight.Controllers
{
    public class HomeController : Controller
    {
        AntRepository _repo;

        public HomeController (ApplicationDbContext context) { _repo = new AntRepository(context); }

        public IActionResult Index ()
        {
            return View(_repo.FlightMessagesView
                            .OrderByDescending(f => f.FlightTime)
                            .Take(12)
                            .ToList());
        }


        public IActionResult Error ()
        {
            return View();
        }
    }
}
