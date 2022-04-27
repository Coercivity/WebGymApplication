using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.Services;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Controllers
{
    public class AuthorizationController : Controller
    {

        private readonly AuthorizationService _authorizationService;
        private readonly RegistrationService _registrationService;
        public AuthorizationController(AuthorizationService authorizationService, RegistrationService registrationService)
        {
            _authorizationService = authorizationService;
            _registrationService = registrationService;
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

            return View("login");
        }


        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> TryRegister(string login, string password, string email)
        {
            var code = await _registrationService.Registrate(login, password, email);
            if (code == RegistrationStatus.Successuful)
                return Redirect("/login");
            return View();
        }
    }
}
