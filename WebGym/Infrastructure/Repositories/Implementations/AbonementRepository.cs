using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Infrastructure.Repositories
{
    public class AbonementRepository : IAbonementRepository
    {

        private readonly GymDbContext _gymDbContext;

        public AbonementRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<Abonement> GetAllAbonementsByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Abonement> GetValidAbonementByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
