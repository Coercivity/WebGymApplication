using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface ICoachRepository
    {
        public Task<CoachDto> GetCoachByIdAsync(Guid id);
        public Task<List<CoachDto>> GetAllCoachesAsync();
        public Task<bool> UpdateCoachAccountAsync(AccountDto accountDto, CoachDto clientDto);
    }
}
