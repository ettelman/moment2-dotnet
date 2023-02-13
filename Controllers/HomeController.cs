using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using moment2.Models;

namespace moment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.demo = "Välkommen till moment 2!";
            return View();
        }
        [Route("/dogs")]
         public IActionResult Dogs()
        {
            var jsonStr = System.IO.File.ReadAllText("dogs.json");
            var jsonObj = JsonConvert.DeserializeObject<List<Dogs>>(jsonStr);
            return View(jsonObj);
        }
    }
}