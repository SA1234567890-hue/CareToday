using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace blood_bank.Controllers
    {
    public class NurseryController : Controller
    {
        Care_todayContext db;
            public NurseryController(Care_todayContext db)
            {
                this.db = db;
            }
        public IActionResult index()
        {
            return View();
        }

        public IActionResult gdrop()
            {
                SelectList s = new SelectList(db.Governorates.ToList(), "GovId", "GovName");

                return View(s);
            }

            public IActionResult cdrop(string id)
            {
                SelectList s = new SelectList(db.Cities.Where(c => c.Gov.GovName == id).ToList(), "CityId", "CityName");
                ViewBag.c = s;
                return PartialView();
            }

            public IActionResult nurs_search(string id)
            {
                List<Nursery> n = db.Nurseries.Where(b => b.City.CityName == id).ToList();
                ViewBag.n = n;
                return PartialView();
            }
        }
    }

