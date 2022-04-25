using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AuthorizationRepository : IAuthrorizationRepository
    {
        public async Task<Account> TryAuthorizeAsync(string Login, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
