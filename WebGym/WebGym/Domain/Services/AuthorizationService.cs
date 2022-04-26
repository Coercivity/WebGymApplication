using System;
using System.Collections.Generic;
using System.Linq;
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

       public async Task<Account> AuthorizeAsync(string login, string password)
        {
            var account = await _authorizationRepository.TryAuthorizeAsync(login, password);
            return account;
        }


    }
}
