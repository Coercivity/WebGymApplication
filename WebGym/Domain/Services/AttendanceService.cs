using Domain.DTOs;
using Domain.InterfacesToDb;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IStatisticsRepository _statisticsRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository, IStatisticsRepository statisticsRepository)
        {
            _attendanceRepository = attendanceRepository;
            _statisticsRepository = statisticsRepository;
        }
        
        public async Task<List<AttendanceModel>> GetAllClientsAttendaciesAsync(Guid cliendId)
        {
            var attendaciesDto = await _attendanceRepository.GetAllAttendanciesByStatisticsIdAsync(cliendId);

            var attendacies = new List<AttendanceModel>();

            foreach (var attendanceDto in attendaciesDto)
            {
                attendacies.Add(new AttendanceModel() { 
                    HeadPressure = attendanceDto.HeadPressure,
                    HeartPressure = attendanceDto.HeartPressure,
                    Pulse = attendanceDto.Pulse,
                    Weight = attendanceDto.WeightData
                });
            }

           return attendacies;
        }

        public async Task<bool> UpdateClientStatistics(AttendanceModel attendanceModel)
        {
            var statistics = await _statisticsRepository.GetStatisticsByClientIdAsync((Guid)attendanceModel.StatisticsId);
            if(statistics.VisitsAmount == 0 || statistics.VisitsAmount is null)
            {
                statistics.MedianHeadPressure = attendanceModel.HeadPressure;
                statistics.MedianHeartPressure = attendanceModel.HeartPressure;
                statistics.MedianPulse = attendanceModel.Pulse;
                statistics.WeightData = attendanceModel.Weight;
                statistics.MedianCaloriesSpent = attendanceModel.CaloriesSpent;
                statistics.VisitsAmount = 0;
            }
            else
            {
                statistics.MedianHeadPressure = (statistics.MedianHeadPressure + attendanceModel.HeadPressure) / 2;
                statistics.MedianHeartPressure = (statistics.MedianHeartPressure + attendanceModel.HeartPressure) / 2;
                statistics.MedianPulse = (statistics.MedianPulse + attendanceModel.Pulse) / 2;
                statistics.MedianCaloriesSpent += attendanceModel.CaloriesSpent;
                statistics.WeightData = attendanceModel.Weight;
            }
            statistics.VisitsAmount++;

            var statisticsDto = new StatisticsDataDto()
            {
                Id = statistics.Id,
                MedianHeadPressure = statistics.MedianHeadPressure,
                MedianHeartPressure = statistics.MedianHeartPressure,
                VisitsAmount = statistics.VisitsAmount,
                MedianPulse = statistics.MedianPulse,
                WeightData = statistics.WeightData,
                MedianCaloriesSpent = statistics.MedianCaloriesSpent
                
            };


           var status = await _statisticsRepository.UpdateStatisticsAsync(statistics);

           return status;
        }

        public async Task<bool> AddClientAttendanceAsync(AttendanceModel attendanceModel)
        {

            var attendanceDto = new AttendanceDto()
            {
                Id = Guid.NewGuid(),
                CoachId = attendanceModel.CoachId,
                StartTime = attendanceModel.StartTime,
                FinishTime = attendanceModel.FinishTime,
                WeightData = attendanceModel.Weight,
                CaloriesSpent = attendanceModel.CaloriesSpent,
                HeadPressure = attendanceModel.HeadPressure,
                HeartPressure = attendanceModel.HeartPressure,
                StatisticsDataId = attendanceModel.StatisticsId,
                Pulse = attendanceModel.Pulse,
                TrainTypeId = attendanceModel.TrainTypeId
                
            };

            var status = await _attendanceRepository.AddClientAttendanceAsync(attendanceDto);

            var updateStatus = await UpdateClientStatistics(attendanceModel);
            

            return status;
        }
    }
}
