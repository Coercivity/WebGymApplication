using Domain.Enums;
using Domain.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Handlers.Interfaces;

namespace WebGym.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly AccountService _accountService;
        private readonly IImageUploadHandler _imageUploadHandler;
        private Guid _claimId;

        public AccountController(AccountService accountService, IImageUploadHandler imageUploadHandler)
        {
            _accountService = accountService;
            _imageUploadHandler = imageUploadHandler;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userRole = User.FindFirst(ClaimTypes.Role).Value;

            if (userRole == Role.Coach.ToString())
            {
                var accountModel = await _accountService.GetCoachAccountModelAsync(_claimId);

                return View("CoachAccountView", accountModel);
            }
            else
            {
                var accountModel = await _accountService.GetClientAccountModelAsync(_claimId);

                return View("ClientAccountView", accountModel);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditCoachCredentials()
        {

            _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var accountModel = await _accountService.GetCoachAccountModelAsync(_claimId);
            return View("EditCoachCredentials", accountModel);
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditCoachCredentials(CoachAccountModel coachAccountModel, IFormFile imageFile)
        {
            if (imageFile is not null)
            {
                _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var imagePath = await _imageUploadHandler.UploadImageAndReturnItsName(imageFile);
                var status = await _accountService.UploadAccountImageName(_claimId, imagePath);
            }
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
            _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var accountModel = await _accountService.GetClientAccountModelAsync(_claimId);
            return View("EditClientCredentials", accountModel);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> EditClientCredentials(ClientAccountModel clientAccountModel, IFormFile imageFile)
        {

            if (imageFile is not null)
            {
                _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var imagePath = await _imageUploadHandler.UploadImageAndReturnItsName(imageFile);
                var status = await _accountService.UploadAccountImageName(_claimId, imagePath);
            }

            var isUpdated = await _accountService.UpdateClientAccountAsync(clientAccountModel);
            if(isUpdated)
            {
                return Redirect("/Account");
            }
            return View(clientAccountModel);
        }



    }
}
