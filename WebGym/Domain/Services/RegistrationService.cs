using System.Threading.Tasks;
using WebGym.Domain.Enums;
using WebGym.Domain.InterfacesToDb;

namespace WebGym.Domain.Services
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<RegistrationStatus> Registrate(string login, string password, string email)
        {
            var code = await _registrationRepository.TryRegisterClientAsync(login, password, email);

            return code;
        }
    }
}
