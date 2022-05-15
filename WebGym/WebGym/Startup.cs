using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Domain.Services;
using Infrastructure;
using WebGym.Handlers.Interfaces;
using WebGym.Handlers;

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
                    op.AccessDeniedPath = "/denied";
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

            services.AddDbRepositories(Configuration.GetConnectionString("DefaultConnection"));

            services.AddTransient<AuthorizationService>();
            services.AddTransient<RegistrationService>();
            services.AddTransient<AccountService>();
            services.AddTransient<ScheduleService>();
            services.AddTransient<AbonementService>();
            services.AddTransient<AttendanceService>();
            services.AddTransient<ChartHandler>();
            services.AddTransient<IImageUploadHandler, ImageHandler>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
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


    