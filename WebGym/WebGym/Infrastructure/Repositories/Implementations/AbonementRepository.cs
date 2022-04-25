using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class AbonementRepository : IAbonementRepository
    {
        public async Task<Abonement> GetAllAbonementsByClientIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Abonement> GetValidAbonementByClientIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
