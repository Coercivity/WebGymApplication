using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebGym.Controllers
{
    public class TeamController : Controller
    {
        private readonly AccountService _accountService;

        public TeamController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var coaches = await _accountService.GetAllCoachAccountModelAsync();
            return View(coaches);
        }
    }
}
