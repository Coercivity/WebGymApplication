using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        public Task<IEnumerable<Service>> GetAllServicesByClientIdAsync();
    }
}
