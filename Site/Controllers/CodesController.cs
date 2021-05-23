using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using Site.Data;
using Site.Models;
using Site.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class CodesController : BaseController
    {
        CodeGenerator _gen;
        IHubContext<Hubs> _hub;
        ApplicationDbContext _db;
        public CodesController(
            CodeGenerator generator,
            IHubContext<Hubs> hub,
            ApplicationDbContext db, UserManager<IdentityUser> um):base(um)
        {
            _gen = generator;
            _hub = hub;
            _db = db;
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            _gen.GenCode();
            PinCodeModel m = new PinCodeModel();
            m.Code = _gen.Code;
            m.Exp = _gen.GenTime.AddMinutes(5);
            return View(m);
        }

        [HttpGet]
        public IActionResult EnterCode()
        {
            return View(new EnterCodeModel());
        }

        [HttpPost]
        public IActionResult EnterCode(int code)
        {
            EnterCodeModel m = new EnterCodeModel();
            if (_gen.Code == code)
            {
                m.Message = "OK";
                m.Status = EnterCodeModel.StatusOK;

                Present p = new Present();
                p.Date = DateTime.Now;
                p.UserId = UserId;

                _db.Presents.Add(p);
                _db.SaveChanges();

                _hub.Clients.All.SendAsync("UpdateCode");
            }
            else
            {
                m.Message = "Error";
                m.Status = EnterCodeModel.StatusError;
            }
            return View(m);
        }
    }
}
