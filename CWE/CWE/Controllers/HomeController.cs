using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CWE.Models;

namespace CWE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Help()
        {
            ViewData["Message"] = "CW Currency Exchange - Currncy Rate Application";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
