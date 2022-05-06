using Domain.Enums;
using Domain.InterfacesToDb;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Domain.Services
{
    public class AuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        private List<Claim> _claims;

        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

       public async Task<ClaimsPrincipal> AuthorizeAsync(string login, string password)
        {
            var account = await _authorizationRepository.TryAuthorizeAsync(login, password);

            if(account is null)
                return null;

            _claims = new List<Claim>{ new Claim("username", account.LoginData),
                                       new Claim(ClaimTypes.NameIdentifier,account.Id.ToString())};

            if (account.GroupId == (int)Role.Coach)
            {
                _claims.Add(new Claim(ClaimTypes.Role, Role.Coach.ToString()));
            }
            else
            {
                _claims.Add(new Claim(ClaimTypes.Role, Role.Client.ToString()));
            }


            var claimsIdentity = new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);


            return new ClaimsPrincipal(claimsIdentity);
        }



        
    }
}
