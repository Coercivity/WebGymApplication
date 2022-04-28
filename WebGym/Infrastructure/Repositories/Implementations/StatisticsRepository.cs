using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly GymDbContext _gymDbContext;

        public StatisticsRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<StatisticsData> GetStatisticsByIdAsync(Guid id)
        {
            var statistics = await _gymDbContext.StatisticsData.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return statistics;
        }
    }
}
