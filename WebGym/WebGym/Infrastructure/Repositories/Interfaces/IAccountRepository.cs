using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;

namespace WebGym.Infrastructure
{
    public interface IAccountRepository
    { 
        public Task<Account> GetAccountAsync(string Login, string Password);
        public Task<Client> GetClientByIdAsync(int Id); 
        public Task<Coach> GetCoachByIdAsync(int Id);
        public Task<IEnumerable<Coach>> GetAllCoachesAsync();
        public Task<IEnumerable<Client>> GetAllClientsAsync();

    }
}
