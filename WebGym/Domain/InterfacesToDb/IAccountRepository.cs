﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
