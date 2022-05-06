using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebGym.Domain.ViewModels;

namespace WebGym.Controllers
{
    public class AbonementController : Controller
    {


        [Authorize]
        public IActionResult Index(AbonementModel abonement)
        {
            return View("BuyAbonement", abonement);
        }

        [Authorize]
        public IActionResult BuyAbonement()
        {
            return View();
        }



    }
}
