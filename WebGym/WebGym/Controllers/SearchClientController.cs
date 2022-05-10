using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Controllers
{
    public class SearchClientController : Controller
    {
        private readonly AccountService _accountService;

        public SearchClientController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Index(Guid coachId, string query)
        {
            var clientAccounts = await _accountService.getClientAcountModelsByQueryAsync(query);
            return View(clientAccounts);
        }
    }
}
