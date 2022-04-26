using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly GymDbContext _gymDbContext;

        public RegistrationRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task TryRegisterClientAsync(string login, string password, string email, string firstName, 
            string surname, string Ppatronymic, string mobileNumber)
        {
            _gymDbContext.Accounts.Add( new Account { 
                LoginData = login,
                PasswordData = password,
                Email = email
            });
        }

        public async Task TryRegisterCoachAsync(string Login, string Password, string Email, string FirstName, 
            string Surname, string Patronymic, string MobileNumber, string Rank, int Experience)
        {
            throw new NotImplementedException();
        }
    }
}
