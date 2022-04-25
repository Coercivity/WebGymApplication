using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        public async Task<StatisticsData> GetStatisticsByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
