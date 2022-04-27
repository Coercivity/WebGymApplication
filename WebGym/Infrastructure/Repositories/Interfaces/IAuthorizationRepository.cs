using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAuthorizationRepository
    {
        public Task<Account> TryAuthorizeAsync(string login, string password);
    }
}
