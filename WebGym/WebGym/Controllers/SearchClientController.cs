using Domain.Services;
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

        public async Task<IActionResult> Index(Guid coachId, string query)
        {
            var clientAccounts = await _accountService.getClientAcountModelByQueryAsync(query);
            return View(clientAccounts);
        }
    }
}
