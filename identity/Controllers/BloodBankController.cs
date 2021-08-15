using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace blood_bank.Controllers
{
    public class BloodBankController : Controller
    {
        Care_todayContext db;
        public BloodBankController(Care_todayContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult dropgov()
        {
            SelectList s = new SelectList(db.Governorates.ToList(), "GovId", "GovName");
            return View(s);
        }
        public IActionResult citydrop(string id)
        {
            SelectList c = new SelectList(db.Cities.Where(c => c.Gov.GovName == id).ToList(), "CityId", "CityName");
            ViewBag.c = c;
            return PartialView();
        }
        public IActionResult blood_search(string id)
        {
            List<BloodBank> b = db.BloodBanks.Where(b => b.City.CityName == id).ToList();
            ViewBag.b = b;
            return PartialView();
        }
    }
}
