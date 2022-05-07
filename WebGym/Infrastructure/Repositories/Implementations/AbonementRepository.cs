using Domain.DTOs;
using Domain.InterfacesToDb;
using Infrastructure.efModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories.Implementations
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
            var abonement = await _gymDbContext.Abonements.Where(x => x.ClientId.Equals(id)).FirstOrDefaultAsync();
            if (abonement is null)
                return null;
            return Mapper.MapAbonement(abonement);
        }

        public async Task<bool> TryToBuyAbonementAsync(AbonementDto abonementDto)
        {

            var abonement = new Abonement()
            {
                Id = abonementDto.Id,
                ClientId = abonementDto.ClientId,
                IsValid = abonementDto.IsValid,
                FinishDate = abonementDto.FinishDate,
                StartDate = abonementDto.StartDate,
                VisitsAmount = abonementDto.VisitsAmount
                
            };
            try
            {
                await _gymDbContext.Abonements.AddAsync(abonement);
                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}
