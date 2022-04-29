using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.Enums;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IRegistrationRepository
    {
        public Task<RegistrationStatus> TryRegisterClientAsync(string login, string password, string email);
    }
}
