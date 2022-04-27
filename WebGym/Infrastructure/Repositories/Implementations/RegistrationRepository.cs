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
            var account = await _accountRepository.GetAccountByLoginAsync(login);
            if (account is not null)
                return RegistrationStatus.AccountExists;

            _gymDbContext.Accounts.Add( new Account { 
                LoginData = login,
                PasswordData = BCrypt.Net.BCrypt.HashPassword(password),
                Email = email,
                GroupId = (int)Role.Client
            });

            try
            {
                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                return RegistrationStatus.Error;
            }
            return RegistrationStatus.Successuful;
            
        }

    }
}
