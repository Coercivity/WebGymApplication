using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IAuthorizationRepository
    {
        public Task<AccountDto> TryAuthorizeAsync(string login, string password);
    }
}
