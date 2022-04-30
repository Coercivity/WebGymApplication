using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Domain.Enums;
using WebGym.Domain.Services;
using WebGym.Domain.ViewModels;

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


        [HttpGet]
        [Authorize(Roles = "Coach")]
        public IActionResult GetCoachEditView(Guid id)
        {

            return View("EditCoachCredentials");
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditCoachCredentials(CoachAccountModel coachAccountModel)
        {

            var isUpdated = await _accountService.UpdateCoachAccount(coachAccountModel);
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
            var accountModel = await _accountService.GetClientAccountModel(Guid.Parse(claimId));
            return View("EditClientCredentials", accountModel);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> EditClientCredentials(ClientAccountModel clientAccountModel)
        {
            var isUpdated = await _accountService.UpdateClientAccount(clientAccountModel);
            if(isUpdated)
            {
                return Redirect("/Account");
            }
            return View(clientAccountModel);
        }


    }
}
