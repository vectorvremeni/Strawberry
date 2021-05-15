using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        public HomeController(UserManager<IdentityUser> userManager)
        {
            //_roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            /*if (User.Identity.IsAuthenticated)
            {
                IdentityUser u = await _userManager.GetUserAsync(User);
                await _userManager.AddToRoleAsync(u, "Admin");
            }*/
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
