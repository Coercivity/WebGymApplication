using Domain.Enums;
using Domain.InterfacesToDb;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<RegistrationStatus> RegisterAccountAsync(string login, string password, string email)
        {
            var status = await _registrationRepository.TryRegisterClientAsync(login, password, email);

            return status;
        }
    }
}
