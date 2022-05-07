using Domain.Services;
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

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Index(Guid clientId)
        {
            var clientAccount = await _accountService.GetClientAccountModelAsync(clientId);
            return View(clientAccount);
        }

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Update(int headPressure, int heartPressure, int caloriesSpent, 
                                                double weight, int pulse, Guid clientId, Guid statisticsId)
        {
            /*
             *  public Guid? CoachId { get; set; }
                public Guid? TrainTypeId { get; set; }
                public DateTime? TrainTime { get; set; }
                public string TrainType { get; set; }*/

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
                
            };

            var status = await _attendanceService.AddClientAttendanceAsync(attendanceModel);
            return Redirect("/");
        }
    }
}
