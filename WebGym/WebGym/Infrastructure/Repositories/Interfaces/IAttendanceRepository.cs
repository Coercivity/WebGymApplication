using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        public Task<List<Attendance>> GetAllAttendanciesByClientIdAsync();
        public Task<Attendance> GetLastAttendanceByClientIdAsync();
    }
}
