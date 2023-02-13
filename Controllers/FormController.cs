using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using moment2.Models;

namespace moment2.Controllers
{
    public class FormController : Controller
    {
        
        [HttpGet]
        public IActionResult Add()
        {
            var jsonStr = System.IO.File.ReadAllText("dogs.json");
            var jsonObj = JsonConvert.DeserializeObject<List<Dogs>>(jsonStr);
            ViewBag.test = jsonObj;
            return View();
        }
        [HttpPost]
        public IActionResult Add(string name, string breed, int age)
        {
            var jsonStr = System.IO.File.ReadAllText("dogs.json");
            var jsonObj = JsonConvert.DeserializeObject<List<Dogs>>(jsonStr);
            var Dog = new moment2.Models.Dogs(name, breed, age);
            jsonObj.Add(Dog);
            var jsonStrtest = JsonConvert.SerializeObject(jsonObj);
            System.IO.File.WriteAllText("dogs.json", jsonStrtest);
            HttpContext.Session.SetString("dogs", jsonStrtest);
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            var dogList = HttpContext.Session.GetString("dogs");
            var allDogs = JsonConvert.DeserializeObject<List<Dogs>>(dogList);
            ViewBag.alldogs = allDogs;
            return View();
        }
      
    }
}