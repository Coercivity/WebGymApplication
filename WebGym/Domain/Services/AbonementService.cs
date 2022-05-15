using Domain.DTOs;
using Domain.Enums;
using Domain.InterfacesToDb;
using System;
using System.Threading.Tasks;


namespace Domain.Services
{
    public class AbonementService
    {
        private readonly IAbonementRepository _abonementRepository;
        private Tariff _tariff;

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

            _tariff = (Tariff)Enum.Parse(typeof(Tariff), tariff);
            double days = 365;

            switch (_tariff)
            {
                case Tariff.A:
                    abonementDto.FinishDate = DateTime.Now.AddDays(days);
                    abonementDto.VisitsAmount = 10000;
                    break;
                case Tariff.B:
                    abonementDto.FinishDate = DateTime.Now.AddDays(days / 2);
                    abonementDto.VisitsAmount = 10000;
                    break;
                case Tariff.C:
                    abonementDto.FinishDate = DateTime.Now.AddDays(days / 4);
                    abonementDto.VisitsAmount = (int)days / 4;
                    break;
                case Tariff.D:
                    abonementDto.FinishDate = DateTime.Now.AddDays(days / 12);
                    abonementDto.VisitsAmount = (int)days / 12;
                    break;
            }

            var status = await _abonementRepository.TryToBuyAbonementAsync(abonementDto);

            return status;
        }
    }
}
