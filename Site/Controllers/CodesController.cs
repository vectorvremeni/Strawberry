using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class CodesController : Controller
    {
        CodeGenerator _gen;
        public CodesController(CodeGenerator generator)
        {
            _gen = generator;
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
