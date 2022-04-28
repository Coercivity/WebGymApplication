using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Infrastructure.Repositories
{

    public class AccountRepository : IAccountRepository
    {

        private readonly GymDbContext _gymDbContext;

        public AccountRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            var clients = await _gymDbContext.Clients.ToListAsync();
            return Mapper.MapClientsDto(clients);
        }

        public async Task<AccountDto> GetAccountByLoginAsync(string login)
        {
            var account = await _gymDbContext.Accounts.Where(x => x.LoginData.Equals(login)).FirstOrDefaultAsync();
            return Mapper.MapAccount(account);
        }

        public async Task<List<CoachDto>> GetAllCoachesAsync()
        {

            var coaches = await _gymDbContext.Coaches.ToListAsync();
            return Mapper.MapCoachesDto(coaches);
        }

        public async Task<ClientDto> GetClientByIdAsync(Guid id)
        {
            var client = await _gymDbContext.Clients.Where(op => op.AccountId.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapClient(client);
        }

        public async Task<CoachDto> GetCoachByIdAsync(Guid id)
        {
            var coach = await _gymDbContext.Coaches.Where(op => op.AccountId.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapCoach(coach);
        }

        public async Task<AccountDto> GetAccountByIdAsync(Guid id)
        {
            var accounts = await _gymDbContext.Accounts.Where(op => op.Id.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapAccount(accounts);
        }

        public async Task<bool> CheckIfAccountExists(string login, string email)
        {
           var account = await _gymDbContext.Accounts.Where(x => x.Email.Equals(email) || x.LoginData.Equals(login)).FirstOrDefaultAsync();
           if (account is not null)
                return true;

            return false;
        }


    }
}
