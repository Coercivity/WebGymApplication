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

            var account = await _gymDbContext.Accounts.Where(op => op.LoginData.Equals(login) 
                                                        && op.PasswordData.Equals(password)).FirstOrDefaultAsync();
            return account;
        }
    }
}
