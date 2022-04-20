using Microsoft.AspNetCore.Mvc;

namespace WebGym.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
