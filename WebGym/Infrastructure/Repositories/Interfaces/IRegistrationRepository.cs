using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        public Task<RegistrationStatus> TryRegisterClientAsync(string Login, string Password, string Email);
    }
}
