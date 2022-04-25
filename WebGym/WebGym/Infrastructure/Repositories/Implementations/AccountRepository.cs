using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;

namespace WebGym.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public enum Role
        {
            Admin = 1,
            Coach = 2,
            Client = 3
        };

        public async Task<Account> GetAccountAsync(string Login, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coach>> GetAllCoachesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClientByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Coach> GetCoachByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
