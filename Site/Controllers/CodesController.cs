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
        public IActionResult Index()
        {
            _gen.GenCode();
            PinCodeModel m = new PinCodeModel();
            m.Code = _gen.Code;
            m.Exp = _gen.GenTime.AddMinutes(5);
            return View(m);
        }
    }
}
