using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {

        public Task TryRegisterClientAsync(string Login, string Password, string Email, string FirstName, 
            string Surname, string Patronymic, string MobileNumber);
        public Task TryRegisterCoachAsync(string Login, string Password, string Email, string FirstName,
            string Surname, string Patronymic, string MobileNumber, string Rank, int Experience);

    }
}
