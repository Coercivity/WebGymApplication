using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebGym.Domain.InterfacesToDb;
using WebGym.Infrastructure;
using WebGym.Infrastructure.Repositories;
using WebGym.Infrastructure.Repositories.Implementations;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbRepositories(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<GymDbContext>(op => op.UseSqlServer(connectionString));


            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IAbonementRepository, AbonementRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();

            services.AddDbContext<GymDbContext>(x => x.UseSqlServer(connectionString));

            return services;
        }
    }
}
