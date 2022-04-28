using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly GymDbContext _gymDbContext;

        public StatisticsRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<StatisticsDataDto> GetStatisticsByIdAsync(Guid id)
        {
            var statistics = await _gymDbContext.StatisticsData.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapStatisticsData(statistics);
        }
    }
}
