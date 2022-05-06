using System;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IStatisticsRepository
    {
        public Task<StatisticsDataDto> GetStatisticsByClientIdAsync(Guid id);
    }
}
