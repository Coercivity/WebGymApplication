using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        public Task<List<Attendance>> GetAllAttendanciesByStatisticsIdAsync(Guid id);
        public Task<Attendance> GetLastAttendanceByStatisticsIdAsync(Guid id);
    }
}
