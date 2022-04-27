using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAbonementRepository
    {
        public Task<Abonement> GetValidAbonementByClientIdAsync(Guid id);
        public Task<Abonement> GetAllAbonementsByClientIdAsync(Guid id);
    }
}
