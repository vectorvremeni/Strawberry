using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class BaseController : Controller
    {
        UserManager<IdentityUser> _um;
        public String UserId 
        {
            get
            {
                IdentityUser u = _um.GetUserAsync(User).Result;
                return u.Id;
            }
            private set { } 
        } 
        public BaseController(UserManager<IdentityUser> um)
        {
            _um = um;
        }
    }
}
