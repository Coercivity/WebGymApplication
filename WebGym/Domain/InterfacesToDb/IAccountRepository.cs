using Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace Domain.InterfacesToDb
{
    public interface IAccountRepository
    { 
        public Task<AccountDto> GetAccountByIdAsync(Guid id);
        public Task<bool> CheckIfAccountExists(string login, string email);
        public Task<bool> UploadImage(Guid accountId ,string imageName);
        public Task<AccountDto> GetAccountByLoginAsync(string login); 

        
    }
}
