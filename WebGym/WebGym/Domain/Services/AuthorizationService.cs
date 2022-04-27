using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Domain.Services
{
    public class AuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

       public async Task<ClaimsPrincipal> AuthorizeAsync(string login, string password)
        {
            var account = await _authorizationRepository.TryAuthorizeAsync(login, password);

            if(account is null)
                return null;

            var claims = new List<Claim>() { new Claim("username", account.LoginData), new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())};
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            return new ClaimsPrincipal(claimsIdentity);
        }


        public enum ClaimType 
        {
            Id = 1
        }


        
    }
}
