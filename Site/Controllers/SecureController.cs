using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    [Authorize]
    public class SecureController : Controller
    {

        UserManager<IdentityUser> _userManager;
        public SecureController(UserManager<IdentityUser> userManager)
        {
            //_roleManager = roleManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            UserModel m = new UserModel();
            m.Authenticated = false;
            if (User.Identity.IsAuthenticated)
            {
                IdentityUser u = await _userManager.GetUserAsync(User);
                m.Authenticated = true;
                m.Name = u.Email.Split("@").First();
            }
            return View(m);
        }
    }
}
