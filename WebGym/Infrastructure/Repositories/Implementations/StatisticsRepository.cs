using Domain.DTOs;
using Domain.InterfacesToDb;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly GymDbContext _gymDbContext;

        public StatisticsRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<StatisticsDataDto> GetStatisticsByClientIdAsync(Guid id)
        {
            var statistics = await _gymDbContext.StatisticsData.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapStatisticsData(statistics);
        }

        public async Task<bool> UpdateStatisticsAsync(StatisticsDataDto statisticsDataDto)
        {
            var statistics = await _gymDbContext.StatisticsData.FirstOrDefaultAsync(x => x.Id.Equals(statisticsDataDto.Id));
            try
            {

                statistics.MedianCaloriesSpent = statisticsDataDto.MedianCaloriesSpent;
                statistics.MedianHeadPressure = statisticsDataDto.MedianHeadPressure;
                statistics.MedianHeartPressure = statisticsDataDto.MedianHeartPressure;
                statistics.VisitsAmount = statisticsDataDto.VisitsAmount;
                statistics.WeightData = statisticsDataDto.WeightData;
                statistics.MedianPulse = statisticsDataDto.MedianPulse;

                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public async Task<bool> UploadAttendanceStatisticsAsync(Guid id, StatisticsDataDto statisticsDataDto)
        {
            var statistics = await _gymDbContext.StatisticsData.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return false;
        }
    }
}
