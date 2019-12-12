using CompanyName.Core.Security.JwtSecurity;
using CompanyName.Entities.Data;
using CompanyName.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.Api.Configuration
{
    public static class Auth
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddMyAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = true;

                //TODO
                //options.User.RequireUniqueEmail = true; 
                //options.SignIn.RequireConfirmedEmail = true;
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            JwtTokenDefinitions.LoadFromConfiguration(configuration);
            services.ConfigureJwtAuthentication();
            services.ConfigureJwtAuthorization();
        }
    }
}
