using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories
{


    public class AccountRepository : IAccountRepository
    {

        private readonly GymDbContext _gymDbContext;

        public AccountRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = await _gymDbContext.Clients.ToListAsync();
            return clients;
        }

        public async Task<Account> GetAccountByLoginAsync(string login)
        {
            var account = await _gymDbContext.Accounts.Where(x => x.LoginData.Equals(login)).FirstOrDefaultAsync();
            return account;
        }

        public async Task<List<Coach>> GetAllCoachesAsync()
        {
            var coaches = await _gymDbContext.Coaches.ToListAsync();
            return coaches;
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            var client = await _gymDbContext.Clients.Where(op => op.AccountId.Equals(id)).FirstAsync();
            return client;
        }

        public async Task<Coach> GetCoachByIdAsync(Guid id)
        {
            var coaches = await _gymDbContext.Coaches.Where(op => op.AccountId.Equals(id)).FirstAsync();
            return coaches;
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            var accounts = await _gymDbContext.Accounts.Where(op => op.Id.Equals(id)).FirstAsync();
            return accounts;
        }
    }
}
