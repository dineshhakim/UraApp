using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UraApp.Repository.Abstract;
using UraApp.Repository.Impl;
using UraApp.Repository.Infrastructure;
using UraApp.Services;
using UraApp.Services.Abstract;
using UraApp.Services.Impl;

namespace UraApp.Utility
{
    public class FactoryHelper
    {
        public static void Create(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IConfigurationRoot, ConfigurationRoot>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IRoleTypeService, RoleTypeService>();
            services.AddTransient<IRoleTypeRepository, RoleTypeRepository>();
        }
    }
}
