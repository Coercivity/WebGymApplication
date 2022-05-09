using Domain.DTOs;
using Domain.InterfacesToDb;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastructure.Repositories.Implementations
{

    public class AccountRepository : IAccountRepository, ICoachRepository, IClientRepository
    {

        private readonly GymDbContext _gymDbContext;

        public AccountRepository(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public async Task<List<ClientDto>> GetClientsByQueryAsync(string query)
        {
            var clientAccounts = await (from c in _gymDbContext.Clients
                                           join a in _gymDbContext.Accounts
                                           on c.AccountId equals a.Id
                                           where c.Surname.Contains(query) || c.FirstName.Contains(query) 
                                           select new ClientDto
                                           {
                                               Id = c.Id,
                                               StatisticsDataId = c.Id,
                                               AccountId = a.Id,
                                               Patronymic = c.Patronymic,
                                               FirstName = c.FirstName,
                                               Surname = c.Surname,
                                               PhoneNumber = c.PhoneNumber,
                                               BirthData = c.BirthDate,
                                               ImageName = a.ImagePath

                                           }).ToListAsync();

            return clientAccounts;
        }

        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            var clients = await _gymDbContext.Clients.ToListAsync();
            return Mapper.MapClientsDto(clients);
        }

        public async Task<AccountDto> GetAccountByLoginAsync(string login)
        {
            var account = await _gymDbContext.Accounts.Where(x => x.LoginData.Equals(login)).FirstOrDefaultAsync();
            return Mapper.MapAccount(account);
        }

        public async Task<List<CoachDto>> GetAllCoachesAsync()
        {

            var coachesAccounts = await (from c in _gymDbContext.Coaches
                                        join a in _gymDbContext.Accounts
                                        on c.AccountId equals a.Id
                                        select new CoachDto
                                        {
                                            Id = c.Id,
                                            AccountId = a.Id,
                                            Patronymic = c.Patronymic,
                                            FirstName = c.FirstName,
                                            Surname = c.Surname,
                                            PhoneNumber = c.PhoneNumber,
                                            Degree = c.Degree,
                                            Experience = c.Experience,
                                            ImageName = a.ImagePath

                                        }).ToListAsync();

            return coachesAccounts;
        }

        public async Task<ClientDto> GetClientByIdAsync(Guid id)
        {
            var client = await _gymDbContext.Clients.Where(op => op.AccountId.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapClient(client);
        }

        public async Task<CoachDto> GetCoachByIdAsync(Guid id)
        {
            var coach = await _gymDbContext.Coaches.Where(op => op.AccountId.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapCoach(coach);
        }

        public async Task<AccountDto> GetAccountByIdAsync(Guid id)
        {
            var accounts = await _gymDbContext.Accounts.Where(op => op.Id.Equals(id)).FirstOrDefaultAsync();
            return Mapper.MapAccount(accounts);
        }

        public async Task<bool> CheckIfAccountExists(string login, string email)
        {
           var account = await _gymDbContext.Accounts.Where(x => x.Email.Equals(email) 
                                                || x.LoginData.Equals(login)).FirstOrDefaultAsync();
           if (account is not null)
                return true;

            return false;
        }

        public async Task<bool> UpdateClientAccountAsync(AccountDto accountDto, ClientDto clientDto)
        {

            var account = await _gymDbContext.Accounts.Where(x => x.Id.Equals(accountDto.Id)).FirstOrDefaultAsync();
            var client = await _gymDbContext.Clients.Where(x => x.Id.Equals(accountDto.Id)).FirstOrDefaultAsync();

            account.Email = accountDto.Email;
            client.FirstName = clientDto.FirstName;
            client.Surname = clientDto.Surname;
            client.Patronymic = clientDto.Patronymic;
            client.PhoneNumber = clientDto.PhoneNumber;
            client.BirthDate = clientDto.BirthData;

            try
            {
                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }

        public async Task<bool> UpdateCoachAccountAsync(AccountDto accountDto, CoachDto coachDto)
        {

            var account = await _gymDbContext.Accounts.Where(x => x.Id.Equals(accountDto.Id)).FirstOrDefaultAsync();
            var coach = await _gymDbContext.Coaches.Where(x => x.Id.Equals(accountDto.Id)).FirstOrDefaultAsync();

            account.Email = accountDto.Email;
            coach.FirstName = coachDto.FirstName;
            coach.Surname = coachDto.Surname;
            coach.Patronymic = coachDto.Patronymic;
            coach.PhoneNumber = coachDto.PhoneNumber;
            coach.Experience = coachDto.Experience;
            coach.Degree = coachDto.Degree;

            try
            {
                await _gymDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }

        public async Task<bool> UploadImage(Guid accountId, string imageName)
        {
            var account = await _gymDbContext.Accounts.FirstOrDefaultAsync(x => x.Id.Equals(accountId));
            account.ImagePath = imageName;

            try
            {
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
