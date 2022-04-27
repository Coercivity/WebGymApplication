using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure
{
    public interface IAccountRepository
    { 
        public Task<Client> GetClientByIdAsync(int id); 
        public Task<Account> GetAccountByLoginAsync(string login); 
        public Task<Coach> GetCoachByIdAsync(int id);
        public Task<List<Coach>> GetAllCoachesAsync();
        public Task<List<Client>> GetAllClientsAsync();

    }
}
