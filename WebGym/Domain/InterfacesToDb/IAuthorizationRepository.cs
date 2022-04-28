using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IAuthorizationRepository
    {
        public Task<AccountDto> TryAuthorizeAsync(string login, string password);
    }
}
