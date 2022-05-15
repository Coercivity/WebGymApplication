using Domain.InterfacesToDb;
using Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbRepositories(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<GymDbContext>(op => op.UseSqlServer(connectionString));


            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICoachRepository, AccountRepository>();
            services.AddTransient<IClientRepository, AccountRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IAbonementRepository, AbonementRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();


            return services;
        }
    }
}
