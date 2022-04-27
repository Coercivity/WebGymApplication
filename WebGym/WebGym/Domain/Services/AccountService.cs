using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Domain.ViewModels;
using WebGym.Infrastructure;


namespace WebGym.Domain.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ClientAccountModel> GetClientAccountModel(Guid claimId)
        {

            var client = await _accountRepository.GetClientByIdAsync(claimId);
            var account = await _accountRepository.GetAccountByIdAsync(claimId);

            var accountModel = new ClientAccountModel()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                Surname = client.Surname,
                Patronymic = client.Patronymic,
                MobileNumber = client.PhoneNumber,
                Email = account.Email,
                Login = account.LoginData

            };
            return accountModel;
        }

        internal Task GetClientAccountModel(object p)
        {
            throw new NotImplementedException();
        }
    }
}
