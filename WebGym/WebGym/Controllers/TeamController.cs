using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.InterfacesToDb;
using WebGym.Domain.Services;

namespace WebGym.Controllers
{
    public class TeamController : Controller
    {
        private readonly AccountService _accountService;

        public TeamController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var coaches = await _accountService.GetAllCoachAccountModel();
            return View(coaches);
        }
    }
}
