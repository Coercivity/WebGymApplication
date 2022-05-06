using Domain.Enums;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace WebGym.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TryRegister(string login, string password, string email)
        {
            var code = await _registrationService.RegisterAccountAsync(login, password, email);
            if (code == RegistrationStatus.Successful)
            {
                TempData["registartionSuccess"] = "Успешная регистрация";
                return Redirect("/login");
            }

            if (code == RegistrationStatus.AccountExists)
                TempData["registartionErrorAccountExists"] = "Аккаунт с таким именем уже существует";
            else if (code == RegistrationStatus.Error)
                TempData["registartionError"] = "Ошибка регистрации, попробуйте еще раз";

            return View("Register");
        }
    }
}
