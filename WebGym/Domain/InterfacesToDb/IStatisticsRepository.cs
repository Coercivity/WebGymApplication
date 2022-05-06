using Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IStatisticsRepository
    {
        public Task<StatisticsDataDto> GetStatisticsByClientIdAsync(Guid id);
    }
}
