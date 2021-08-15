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
    [Authorize(Roles = "oxygen tube,Admin")]

    public class OxygenController : Controller
    {
        Care_todayContext db;
        public OxygenController (Care_todayContext db)
        {
            this.db = db;
        }

        public IActionResult index()
        {

            List<OxygenTube> o = db.OxygenTubes.ToList();
            return View(o);
        }
       public IActionResult create()
        {
            List<City> cit = db.Cities.ToList();
            SelectList c = new SelectList(cit, "CityId", "CityName");
            ViewBag.cit = c;
            return View();
        }
        [HttpPost]
        public IActionResult create(OxygenTube n)
        {
            if (ModelState.IsValid)
            {
                db.OxygenTubes.Add(n);
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
        public IActionResult delete(int id)
        {
            OxygenTube s = db.OxygenTubes.Where(n => n.OxgnId == id).SingleOrDefault();
            db.OxygenTubes.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult edit(int id)
        {
            OxygenTube s = db.OxygenTubes.Where(n => n.OxgnId == id).SingleOrDefault();
            List<City> cit = db.Cities.ToList();
            SelectList c = new SelectList(cit, "CityId", "CityName");
            ViewBag.cit = c;
            return View(s);
        }
        [HttpPost]
        public IActionResult edit(OxygenTube so)
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


