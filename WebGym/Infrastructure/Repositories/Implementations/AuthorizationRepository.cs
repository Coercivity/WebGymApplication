using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AuthorizationRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<AccountDto> TryAuthorizeAsync(string login, string password)
        {
            var account = await _gymDbContext.Accounts.Where(x => x.LoginData.Equals(login)).FirstOrDefaultAsync();

            if (account is null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(password, account.PasswordData);
            if (isValid)
                return Mapper.MapAccount(account);

            return null;
        }


    }
}
