using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blood_bank.Controllers
{
    public class BeginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
