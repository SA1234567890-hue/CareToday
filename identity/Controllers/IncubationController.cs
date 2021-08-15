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
    [Authorize(Roles = "nursery,Admin")]
    //[Authorize(Roles = "Admin")]
    public class IncubationController : Controller
    {
        Care_todayContext db;
        public IncubationController(Care_todayContext db)
        {
            this.db = db;
        }

        public IActionResult index()
        {

            List<Nursery> o = db.Nurseries.ToList();
            return View(o);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Nursery n)
        {
            if (ModelState.IsValid)
            {
                db.Nurseries.Add(n);
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
           Nursery s = db.Nurseries.Where(n => n.NurId == id).SingleOrDefault();
            db.Nurseries.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult edit(int id)
        {
            Nursery s = db.Nurseries.Where(n => n.NurId == id).SingleOrDefault();
            List<City> cit = db.Cities.ToList();
            SelectList c = new SelectList(cit, "CityId", "CityName");
            ViewBag.cit = c;
            return View(s);
        }
        [HttpPost]
        public IActionResult edit(Nursery so)
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
