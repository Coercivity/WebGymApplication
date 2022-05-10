using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebGym.Controllers
{
    public class AbonementController : Controller
    {
        private readonly AbonementService _aboementService;

        public AbonementController(AbonementService aboementService)
        {
            _aboementService = aboementService;
        }

        [Authorize(Roles = "Client")]
        public IActionResult Index(Guid clientId)
        {
            return View("BuyAbonement", clientId);
        }

        [Authorize(Roles = "Client")]
        public IActionResult BuyAbonement(Guid clientId, string tariff)
        {
            var status = _aboementService.BuyAbonementAsync(clientId, tariff);
            return Redirect("/Account");
        }



    }
}
