using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AttendanceRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<List<Attendance>> GetAllAttendanciesByStatisticsIdAsync(Guid id)
        {
            var attendances = await _gymDbContext.Attendances.Where(x => x.StatisticsDataId.Equals(id)).ToListAsync();
            return attendances;
        }

        public Task<Attendance> GetLastAttendanceByStatisticsIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
