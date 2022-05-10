﻿using Domain.Services;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebGym.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AttendanceService _attendanceService;
        private readonly AccountService _accountService;

        public AttendanceController(AttendanceService attendanceService, AccountService accountService)
        {
            _attendanceService = attendanceService;
            _accountService = accountService;
        }


        
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> ShowAttendaices(Guid clientId)
        {
            var clientAccount = await _attendanceService.GetAllClientsAttendaciesAsync(clientId);
            return View("Attendancies",clientAccount);
        }

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Index(Guid clientId)
        {
            var clientAccount = await _accountService.GetClientAccountModelAsync(clientId);
            return View(clientAccount);
        }

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Update(int headPressure, int heartPressure, int caloriesSpent, 
                                                double weight, int pulse, Guid clientId, Guid statisticsId, 
                                                Guid trainTypeId)
        {


            var claimId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var attendanceModel = new AttendanceModel()
            { 
                CoachId = claimId,
                Id = Guid.NewGuid(),
                CaloriesSpent = caloriesSpent,
                Pulse = pulse,
                StatisticsId = statisticsId,
                HeadPressure = headPressure,
                HeartPressure = heartPressure,
                Weight = weight,
                TrainTypeId = trainTypeId
                
            };

            var success = await _attendanceService.AddClientAttendanceAsync(attendanceModel);
            if(success)
            {
                ViewData["Response"] = "Успешная отметка";
                return Redirect("/Account");
            }

            return Redirect("/Account");
        }
    }
}
