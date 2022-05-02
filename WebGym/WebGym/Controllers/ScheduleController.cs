using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebGym.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Index()
        {
           var schedule = await _scheduleService.GetCurrentSchedule(Guid.NewGuid());
            return View(schedule);
        }
    }
}
