using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace identity.Controllers
{
    [Authorize(Roles = "blood,Admin")]
  
    public class BloodController : Controller
    {
       
        Care_todayContext db;
        public BloodController(Care_todayContext db)
        {
            this.db = db;
        }

        public IActionResult index()
        {

            List<BloodBank> o = db.BloodBanks.ToList();
            return View(o);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(BloodBank n)
        {
            if (ModelState.IsValid)
            {
                db.BloodBanks.Add(n);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult delete(int id)
        {
            BloodBank s = db.BloodBanks.Where(n => n.BloodId == id).SingleOrDefault();
            db.BloodBanks.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult edit(int id)
        {
            BloodBank s = db.BloodBanks.Where(n => n.BloodId == id).SingleOrDefault();
            List<City> cit = db.Cities.ToList();
            SelectList c = new SelectList(cit, "CityId", "CityName");
            ViewBag.cit = c;
            return View(s);
        }
        [HttpPost]
        public IActionResult edit(BloodBank so)
        {
            if (ModelState.IsValid)
            {

                db.Entry(so).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                List<City> cit = db.Cities.ToList();
                SelectList c = new SelectList(cit, "CityId", "CityName");
                ViewBag.cit = c;
                return View();

            }
        }
    }
}

