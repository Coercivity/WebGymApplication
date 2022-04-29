﻿using System;
using System.Threading.Tasks;
using WebGym.Domain.InterfacesToDb;
using WebGym.Domain.ViewModels;


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
                //ClientAttendances = attendancies

                
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





        public async Task<CoachAccountModel> GetCoachAccountModel(Guid claimId)
        {
            var coach = await _accountRepository.GetCoachByIdAsync(claimId);
            var account = await _accountRepository.GetAccountByIdAsync(claimId);
            


            var accountModel = new CoachAccountModel()
            {
                Id = coach.Id,
                FullName = coach.FirstName + " " + coach.Surname + " " + coach.Patronymic,
                FirstName = coach.FirstName,
                Surname = coach.Surname,
                Patronymic = coach.Patronymic,
                MobileNumber = coach.PhoneNumber,
                Email = account.Email,
                Login = account.LoginData,
                Experience = coach.Experience,
                Rank = coach.Degree


            };
            return accountModel;
        }






    }
}
