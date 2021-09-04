using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult CarsInGarage()
        //{
        //    return View();
        //}
    }
}
