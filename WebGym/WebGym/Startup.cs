using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WebGym.Domain.Services;
using WebGym.Infrastructure;
using WebGym.Infrastructure.Repositories;
using WebGym.Infrastructure.Repositories.Implementations;
using WebGym.Infrastructure.Repositories.Interfaces;

namespace WebGym
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(op => {
                    op.LoginPath = "/login";
                    //For claims checking purpose
                    op.Events = new CookieAuthenticationEvents()
                    {
                        OnSigningIn = async context =>
                        {
                            await Task.CompletedTask;
                        },
                        OnSignedIn = async context =>
                        {
                            await Task.CompletedTask;
                        }, 
                        OnValidatePrincipal = async context =>
                        {
                            await Task.CompletedTask;
                        }
                    };
                });
            services.AddDbContext<GymDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<IAbonementRepository, AbonementRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<AuthorizationService>();
            services.AddTransient<RegistrationService>();
            services.AddTransient<AccountService>();


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}


    