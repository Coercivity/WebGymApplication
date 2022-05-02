using System;
using System.Threading.Tasks;
using WebGym.Domain.DTOs;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Infrastructure.Repositories.Implementations
{
    public class AbonementRepository : IAbonementRepository
    {

        private readonly GymDbContext _gymDbContext;

        public AbonementRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }


        public async Task<AbonementDto> GetAllAbonementsByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AbonementDto> GetValidAbonementByClientIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
