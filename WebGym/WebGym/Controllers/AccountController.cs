using Domain.Enums;
using Domain.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;


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
                var accountModel = await _accountService.GetCoachAccountModelAsync(Guid.Parse(claimId));

                return View("CoachAccountView", accountModel);
            }
            else
            {
                var accountModel = await _accountService.GetClientAccountModelAsync(Guid.Parse(claimId));

                return View("ClientAccountView", accountModel);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditCoachCredentials()
        {

            var claimId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var accountModel = await _accountService.GetCoachAccountModelAsync(Guid.Parse(claimId));
            return View("EditCoachCredentials", accountModel);
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditCoachCredentials(CoachAccountModel coachAccountModel)
        {

            var isUpdated = await _accountService.UpdateCoachAccountAsync(coachAccountModel);
            if (isUpdated)
            {
                return Redirect("/Account");
            }
            return View(coachAccountModel);
        }


        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> EditClientCredentials()
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var accountModel = await _accountService.GetClientAccountModelAsync(Guid.Parse(claimId));
            return View("EditClientCredentials", accountModel);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> EditClientCredentials(ClientAccountModel clientAccountModel)
        {
            var isUpdated = await _accountService.UpdateClientAccountAsync(clientAccountModel);
            if(isUpdated)
            {
                return Redirect("/Account");
            }
            return View(clientAccountModel);
        }


    }
}
