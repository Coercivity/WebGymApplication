using Domain.Enums;
using Domain.Services;
using Domain.ViewModels;
using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebGym.Handlers;
using WebGym.Handlers.Interfaces;

namespace WebGym.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly AccountService _accountService;
        private readonly AttendanceService _attendanceService;
        private readonly ChartHandler _chartHandler;
        private readonly IImageUploadHandler _imageUploadHandler;
        private Guid _claimId;

        public AccountController(AccountService accountService, IImageUploadHandler imageUploadHandler,
            ChartHandler chartHandler, AttendanceService attendanceService)
        {
            _accountService = accountService;
            _imageUploadHandler = imageUploadHandler;
            _chartHandler = chartHandler;
            _attendanceService = attendanceService;

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



        [HttpGet]
        public async Task<ActionResult> PieChartData()
        {
            _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //to refactor
            var accountModel = await _accountService.GetClientAccountModelAsync(_claimId);

            var chart = _chartHandler.GetPieChart(accountModel);

            return Content(chart);
        }


        [HttpGet]
        public async Task<ActionResult> LineChartData()
        {
            _claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //to refactor
            var attendancies = await _attendanceService.GetAllClientsAttendaciesAsync(_claimId);

            var chart = _chartHandler.GetLineChart(attendancies);

            return Content(chart);
        }

    }
}
