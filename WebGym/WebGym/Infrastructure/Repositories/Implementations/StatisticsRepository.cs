using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        public Task<Statistics> GetStatisticsByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
