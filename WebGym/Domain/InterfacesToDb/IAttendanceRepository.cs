using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.InterfacesToDb
{
    public interface IAttendanceRepository
    {
        public Task<List<AttendanceDto>> GetAllAttendanciesByStatisticsIdAsync(Guid id);
        public Task<AttendanceDto> GetLastAttendanceByStatisticsIdAsync(Guid id);
    }
}
