using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace blood_bank.Controllers
{
    public class OxygensController : Controller
    {
            Care_todayContext db;
            public OxygensController(Care_todayContext db)
            {
                this.db = db;
            }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult govdrop()
            {
                SelectList s = new SelectList(db.Governorates.ToList(), "GovId", "GovName");
                return View(s);
            }

            public IActionResult drop_city(string id)
            {
                SelectList c = new SelectList(db.Cities.Where(c => c.Gov.GovName == id).ToList(), "CityId", "CityName");
                ViewBag.c = c;
                return PartialView();
            }

            public IActionResult oxygen_search(string id)
            {
                List<OxygenTube> o = db.OxygenTubes.Where(b => b.City.CityName == id).ToList();
                ViewBag.o = o;
                return PartialView();
            }

        
    }
}
