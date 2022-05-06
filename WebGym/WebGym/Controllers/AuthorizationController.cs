using Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace WebGym.Controllers
{
    public class AuthorizationController : Controller
    {

        private readonly AuthorizationService _authorizationService;
        
        public AuthorizationController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "/")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Validate(string login, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var claimsPrincipal = await _authorizationService.AuthorizeAsync(login, password);

            if (claimsPrincipal is not null)
            {
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }

            TempData["authError"] = "Ошибка.Проверьте правильность введенных данных";
            return View("login");
        }


        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }



    }
}
