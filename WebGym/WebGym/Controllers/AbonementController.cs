using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Controllers
{
    public class AbonementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
