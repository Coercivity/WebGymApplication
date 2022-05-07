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

            var id = Guid.Parse("CA1B624B-3CD1-4ACF-8B20-9FB375F23E6D");
            var schedule = await _scheduleService.GetCurrentSchedule(id);
            return View(schedule);
        }
    }
}
