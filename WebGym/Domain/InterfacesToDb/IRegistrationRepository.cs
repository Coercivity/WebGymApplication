using Domain.Enums;
using System.Threading.Tasks;


namespace Domain.InterfacesToDb
{
    public interface IRegistrationRepository
    {
        public Task<RegistrationStatus> TryRegisterClientAsync(string login, string password, string email);
    }
}
