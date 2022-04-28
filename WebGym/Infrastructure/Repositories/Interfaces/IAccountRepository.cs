using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure
{
    public interface IAccountRepository
    { 
        public Task<Client> GetClientByIdAsync(Guid id); 
        public Task<Account> GetAccountByIdAsync(Guid id); 
        public Task<Account> GetAccountByLoginAsync(string login); 
        public Task<Coach> GetCoachByIdAsync(Guid id);
        public Task<List<Coach>> GetAllCoachesAsync();
        public Task<List<Client>> GetAllClientsAsync();
        public Task<bool> CheckIfAccountExists(string login, string email);
    }
}
