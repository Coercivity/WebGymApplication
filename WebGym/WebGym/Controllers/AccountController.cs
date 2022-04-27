using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Domain.Services;
using WebGym.Domain.ViewModels;
using WebGym.Infrastructure;

namespace WebGym.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var accountModel = await _accountService.GetClientAccountModel(Guid.Parse(claimId));

            return View(accountModel);
        }
    }
}
