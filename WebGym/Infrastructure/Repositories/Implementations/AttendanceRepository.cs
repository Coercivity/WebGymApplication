using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AttendanceRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
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
