using Domain.DTOs;
using Domain.InterfacesToDb;
using Infrastructure.efModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AttendanceRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<bool> AddClientAttendanceAsync(AttendanceDto attendanceDto)
        {
            var attendance = new Attendance()
            {
                CoachId = attendanceDto.CoachId,
                StartTime = attendanceDto.StartTime,
                FinishTime = attendanceDto.FinishTime,
                Id = Guid.NewGuid(),
                StatisticsDataId = attendanceDto.StatisticsDataId,
                WeightData = attendanceDto.WeightData,
                CaloriesSpent = attendanceDto.CaloriesSpent,
                Pulse = attendanceDto.Pulse,
                HeartPressure = attendanceDto.HeartPressure,
                HeadPressure = attendanceDto.HeadPressure

            };

            try
            {
                await _gymDbContext.Attendances.AddAsync(attendance);
                await _gymDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public async Task<List<AttendanceDto>> GetAllAttendanciesByStatisticsIdAsync(Guid id)
        {
            
            var attendances = await _gymDbContext.Attendances.Where(x => x.StatisticsDataId.Equals(id)).ToListAsync();
            return Mapper.MapAttendancesDto(attendances);
        }

        public Task<AttendanceDto> GetLastAttendanceByStatisticsIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
