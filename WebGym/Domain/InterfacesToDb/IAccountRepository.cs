using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IAccountRepository
    { 
        public Task<ClientDto> GetClientByIdAsync(Guid id); 
        public Task<AccountDto> GetAccountByIdAsync(Guid id); 
        public Task<AccountDto> GetAccountByLoginAsync(string login); 
        public Task<CoachDto> GetCoachByIdAsync(Guid id);
        public Task<List<CoachDto>> GetAllCoachesAsync();
        public Task<List<ClientDto>> GetAllClientsAsync();
        public Task<bool> CheckIfAccountExists(string login, string email);
        public Task<bool> UpdateClientAccount(AccountDto accountDto, ClientDto clientDto);
        public Task<bool> UpdateCoachAccount(AccountDto accountDto, CoachDto clientDto);
    }
}
