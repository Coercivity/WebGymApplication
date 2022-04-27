using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Domain.Services;
using WebGym.Infrastructure.Repositories.Interfaces;

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
