using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Domain.Enums;
using WebGym.Domain.Services;


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
            var userRole = User.FindFirst(ClaimTypes.Role).Value;

            if (userRole == Role.Coach.ToString())
            {
                var accountModel = await _accountService.GetCoachAccountModel(Guid.Parse(claimId));

                return View("CoachAccountView", accountModel);
            }
            else
            {
                var accountModel = await _accountService.GetClientAccountModel(Guid.Parse(claimId));

                return View("ClientAccountView", accountModel);
            }
        }



        [Authorize]
        public async Task<IActionResult> EditCredentials()
        {


            return View();
        }
    }
}
