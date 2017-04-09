using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AntFlight.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public TestController (RoleManager<IdentityRole> roleManger)
        {
            _roleManager = roleManger;
        }

        public async Task<IActionResult> Index ()
        {
            return View();
        }
    }
}