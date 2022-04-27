using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AuthorizationRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<Account> TryAuthorizeAsync(string login, string password)
        {
            var account = await _gymDbContext.Accounts.Where(x => x.LoginData.Equals(login)).FirstOrDefaultAsync();

            if (account is null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(password, account.PasswordData);
            if (isValid)
                return account;

            return null;
        }


    }
}
