using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.ViewModels;
using WebGym.Infrastructure;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym.Domain.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public AccountService(IAccountRepository accountRepository, IStatisticsRepository statisticsRepository, 
            IAttendanceRepository attendanceRepository)
        {
            _accountRepository = accountRepository;
            _statisticsRepository = statisticsRepository;
            _attendanceRepository = attendanceRepository;
        }

        public async Task<ClientAccountModel> GetClientAccountModel(Guid claimId)
        {
            var client = await _accountRepository.GetClientByIdAsync(claimId);
            var account = await _accountRepository.GetAccountByIdAsync(claimId);
            var statistics = await _statisticsRepository.GetStatisticsByIdAsync(claimId);
            var attendancies = await _attendanceRepository.GetAllAttendanciesByStatisticsIdAsync(claimId);
           

            var accountStatistics = new StatisticsModel()
            {
                MedianHeadPressure = statistics.MedianHeadPressure,
                MedianHeartPressure = statistics.MedianHeartPressure,
                MedianPulse = statistics.MedianPulse,
                Weight = statistics.WeightData,
                VisitsAmount = statistics.VisitsAmount
            
                
                
                
               

                
            };
            var accountModel = new ClientAccountModel()
            {
                Id = client.Id,
                FullName = client.FirstName + " " + client.Surname + " " + client.Patronymic,
                FirstName = client.FirstName,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                MobileNumber = client.PhoneNumber,
                Email = account.Email,
                Login = account.LoginData,
                AccountStatistics = accountStatistics

            };
            return accountModel;
        }


    }
}
