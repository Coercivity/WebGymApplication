using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IClientRepository
    {
        public Task<List<ClientDto>> GetAllClientsAsync();
        public Task<ClientDto> GetClientByIdAsync(Guid id);
        public Task<bool> UpdateClientAccountAsync(AccountDto accountDto, ClientDto clientDto);
    }
}
