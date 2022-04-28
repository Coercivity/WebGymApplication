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
        private readonly IAccountRepository _accountRepository ;

        public RegistrationRepository(GymDbContext gymDbContext, IAccountRepository accountRepository)
        {
            _gymDbContext = gymDbContext;
            _accountRepository = accountRepository;
        }

        public async Task<RegistrationStatus> TryRegisterClientAsync(string login, string password, string email)
        {
            var accountExists = await _accountRepository.CheckIfAccountExists(login, email);
            if (accountExists)
                return RegistrationStatus.AccountExists;

            var id = Guid.NewGuid();

            _gymDbContext.Accounts.Add( new Account { 
                Id = id,
                LoginData = login,
                PasswordData = BCrypt.Net.BCrypt.HashPassword(password),
                Email = email,
                GroupId = (int)Role.Client
            });

            _gymDbContext.StatisticsData.Add(new StatisticsData
            {
                Id = id
            });

            _gymDbContext.Clients.Add(new Client
            {
                Id = id,
                StatisticsDataId = id,
                AccountId = id
            });

            try
            {
                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return RegistrationStatus.Error;
            }
            return RegistrationStatus.Successful;
            
        }

    }
}
