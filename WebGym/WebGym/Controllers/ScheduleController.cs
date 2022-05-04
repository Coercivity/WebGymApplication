using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGym.Domain.Services;

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

            var id = Guid.Parse("A0A00AD4-C568-4A51-B67D-9C3C0696396F");
           var schedule = await _scheduleService.GetCurrentSchedule(id);
            return View(schedule);
        }
    }
}
