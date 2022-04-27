using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public async Task<List<Attendance>> GetAllAttendanciesByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Attendance> GetLastAttendanceByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
