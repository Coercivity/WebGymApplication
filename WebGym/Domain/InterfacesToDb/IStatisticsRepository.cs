using System;
using System.Threading.Tasks;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IStatisticsRepository
    {
        public Task<StatisticsDataDto> GetStatisticsByIdAsync(Guid id);
    }
}
