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

        public enum Role
        {
            Admin = 1,
            Coach = 2,
            Client = 3
        };


        public async Task<List<Client>> GetAllClientsAsync()
        {
            var clients = await _gymDbContext.Clients.ToListAsync();
            return clients;
        }

        public async Task<List<Coach>> GetAllCoachesAsync()
        {
            var coaches = await _gymDbContext.Coaches.ToListAsync();
            return coaches;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var client = await _gymDbContext.Clients.Where(op => op.AccountId.Equals(id)).FirstAsync();
            return client;
        }

        public async Task<Coach> GetCoachByIdAsync(int id)
        {
            var coaches = await _gymDbContext.Coaches.Where(op => op.AccountId.Equals(id)).FirstAsync();
            return coaches;
        }
    }
}
