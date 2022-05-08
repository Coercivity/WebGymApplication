using Domain.Enums;
using Domain.InterfacesToDb;
using Infrastructure.efModels;
using System;
using System.Threading.Tasks;



namespace Infrastructure.Repositories.Implementations
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

            await _gymDbContext.Accounts.AddAsync( new Account { 
                Id = id,
                LoginData = login,
                PasswordData = BCrypt.Net.BCrypt.HashPassword(password),
                Email = email,
                GroupId = (int)Role.Client,
                ImagePath = "defaultProfileImage.png"
            });

            await _gymDbContext.StatisticsData.AddAsync(new StatisticsData
            {
                Id = id
            });

           await _gymDbContext.Clients.AddAsync(new Client
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
