using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public async Task TryRegisterClientAsync(string Login, string Password, string Email, string FirstName, 
            string Surname, string Patronymic, string MobileNumber)
        {
            throw new NotImplementedException();
        }

        public async Task TryRegisterCoachAsync(string Login, string Password, string Email, string FirstName, 
            string Surname, string Patronymic, string MobileNumber, string Rank, int Experience)
        {
            throw new NotImplementedException();
        }
    }
}
