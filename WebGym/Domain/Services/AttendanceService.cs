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

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
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

            return status;
        }
    }
}
