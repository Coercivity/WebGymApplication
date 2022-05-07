using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.InterfacesToDb;
using Domain.ViewModels;

namespace Domain.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IAbonementRepository _abonementRepository;

        public AccountService(IAccountRepository accountRepository, IStatisticsRepository statisticsRepository, 
            IAttendanceRepository attendanceRepository, IAbonementRepository abonementRepository,
            ICoachRepository coachRepository, IClientRepository clientRepository)
        {
            _accountRepository = accountRepository;
            _statisticsRepository = statisticsRepository;
            _attendanceRepository = attendanceRepository;
            _abonementRepository = abonementRepository;
            _clientRepository = clientRepository;
            _coachRepository = coachRepository;
        }

        public async Task<ClientAccountModel> GetClientAccountModelAsync(Guid claimId)
        {
            var client = await _clientRepository.GetClientByIdAsync(claimId);
            var account = await _accountRepository.GetAccountByIdAsync(claimId);
            var statistics = await _statisticsRepository.GetStatisticsByClientIdAsync(claimId);
            var attendancies = await _attendanceRepository.GetAllAttendanciesByStatisticsIdAsync(claimId);
            var abonemet = await _abonementRepository.GetValidAbonementByClientIdAsync(claimId);

            var attendanciesModel = new List<AttendanceModel>();
            foreach (var attendance in attendancies)
            {
                attendanciesModel.Add(new AttendanceModel() { 
                    StatisticsId = attendance?.StatisticsDataId,
                    CoachId = attendance?.CoachId,
                    HeadPressure = attendance?.HeadPressure,
                    HeartPressure = attendance?.HeartPressure,
                    Id = attendance?.Id,
                    Pulse = attendance?.Pulse,
                    TrainTime = attendance?.StartTime,
                    Weight = attendance?.WeightData,
                    TrainType = attendance?.TrainType
                }); 
            }
            

            var statisticsModel = new StatisticsModel()
            {
                MedianHeadPressure = statistics.MedianHeadPressure,
                MedianHeartPressure = statistics.MedianHeartPressure,
                MedianPulse = statistics.MedianPulse,
                Weight = statistics.WeightData,
                VisitsAmount = statistics.VisitsAmount,
                ClientAttendances = attendanciesModel

            };

            var abonementModel = new AbonementModel();

            if(abonemet is not null)
            {
                abonementModel.StartDate = abonemet.StartDate;
                abonementModel.FinishDate = abonemet.FinishDate;
                abonementModel.ClientId = abonemet?.ClientId;
                abonementModel.IsValid = (bool)abonemet.IsValid;
                abonementModel.VisitsAmount = abonemet?.VisitsAmount;
            };


            var accountModel = new ClientAccountModel()
            {
                Id = client.Id,
                FullName = client.Surname + " " + client.FirstName + " " + client.Patronymic,
                FirstName = client.FirstName,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                MobileNumber = client.PhoneNumber,
                Email = account.Email,
                Login = account.LoginData,
                Abonement = abonementModel,
                AccountStatistics = statisticsModel

            };
            return accountModel;
        }
        public async Task<bool> UpdateClientAccountAsync(ClientAccountModel accountModel)
        {
            var accountDto = new AccountDto()
            {
                Id = accountModel.Id,
                Email = accountModel.Email
            };
            var clientDto = new ClientDto()
            {
                Surname = accountModel.Surname,
                FirstName = accountModel.FirstName,
                Patronymic = accountModel.Patronymic,
                PhoneNumber = accountModel.MobileNumber
            };

            var response = await _clientRepository.UpdateClientAccountAsync(accountDto, clientDto);

            return response;   
        }
        public async Task<CoachAccountModel> GetCoachAccountModelAsync(Guid claimId)
        {
            var coach = await _coachRepository.GetCoachByIdAsync(claimId);
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
        public async Task<bool> UpdateCoachAccountAsync(CoachAccountModel coachModel)
        {
            var accountDto = new AccountDto()
            {
                Id = coachModel.Id,
                Email = coachModel.Email
            };
            var coachDto = new CoachDto()
            {
                Surname = coachModel.Surname,
                FirstName = coachModel.FirstName,
                Patronymic = coachModel.Patronymic,
                PhoneNumber = coachModel.MobileNumber,
                Degree = coachModel.Rank,
                Experience = coachModel.Experience
            };

            var response = await _coachRepository.UpdateCoachAccountAsync(accountDto, coachDto);

            return response;
        }
        public async Task<List<CoachAccountModel>> GetAllCoachAccountModelAsync()
        {
            var coachesDto = await _coachRepository.GetAllCoachesAsync();
            var coachAccountModels = new List<CoachAccountModel>();
            foreach (var coachDto in coachesDto)
            {

                var coach = new CoachAccountModel()
                {
                    Id = coachDto.Id,
                    FullName = coachDto.FirstName + " " + coachDto.Surname + " " + coachDto.Patronymic,
                    FirstName = coachDto.FirstName,
                    Surname = coachDto.Surname,
                    Patronymic = coachDto.Patronymic,
                    MobileNumber = coachDto.PhoneNumber,
                    Experience = coachDto.Experience,
                    Rank = coachDto.Degree

                };
                coachAccountModels.Add(coach);
            }
            return coachAccountModels;
        }


    }
}
