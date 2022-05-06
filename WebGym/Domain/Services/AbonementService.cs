using Domain.DTOs;
using Domain.InterfacesToDb;
using System;
using System.Threading.Tasks;


namespace Domain.Services
{
    public class AbonementService
    {
        private readonly IAbonementRepository _abonementRepository;

        public AbonementService(IAbonementRepository abonementRepository)
        {
            _abonementRepository = abonementRepository;
        }

        public async Task<bool> BuyAbonementAsync(Guid clientId, string tariff)
        {
            var abonementDto = new AbonementDto()
            {
                ClientId = clientId,
                IsValid = true,
                StartDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var status = await _abonementRepository.TryToBuyAbonementAsync(abonementDto);

            return status;
        }
    }
}
