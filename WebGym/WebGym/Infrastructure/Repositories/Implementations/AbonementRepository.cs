using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.efModels;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class AbonementRepository : IAbonementRepository
    {
        public Task<Abonement> GetAllAbonementsByClientIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Abonement> GetValidAbonementByClientIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
