using Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IStatisticsRepository
    {
        public Task<StatisticsDataDto> GetStatisticsByClientIdAsync(Guid id);


        public Task<bool> UploadAttendanceStatisticsAsync(Guid id, StatisticsDataDto statisticsDataDto);
        public Task<bool> UpdateStatisticsAsync(StatisticsDataDto statisticsDataDto);
    }
}
