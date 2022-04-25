using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        public Task<IEnumerable<Attendance>> GetAllAttendanciesByClientIdAsync();
        public Task<Attendance> GetLastAttendanceByClientIdAsync();
    }
}
