using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IAbonementRepository
    {
        public Task<AbonementDto> GetValidAbonementByClientIdAsync(Guid id);
        public Task<AbonementDto> GetAllAbonementsByClientIdAsync(Guid id);
    }
}
