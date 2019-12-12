using CompanyName.Business.Interfaces;
using CompanyName.Business.Services;
using CompanyName.Core.Security;
using CompanyName.Repository.Generic;
using CompanyName.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyName.Api.Configuration
{
    public static class Service
    {
        /// <summary>
        /// When the program runs, services are injected.
        /// </summary>
        /// <param name="services"></param>
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ITokenService, TokenService>();

        }
    }
}
