using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public async Task<IEnumerable<Service>> GetAllServicesByClientIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
