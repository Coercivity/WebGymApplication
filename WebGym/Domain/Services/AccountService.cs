using System;
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
                FullName = client.Surname + " " + client.FirstName + " " + client.Patronymic,
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

        public async Task<bool> UpdateClientAccount(ClientAccountModel accountModel)
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

            var response = await _accountRepository.UpdateClientAccount(accountDto, clientDto);

            return response;   
        }

        public async Task<bool> UpdateCoachAccount(CoachAccountModel coachModel)
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

            var response = await _accountRepository.UpdateCoachAccount(accountDto, coachDto);

            return response;
        }


    }
}
