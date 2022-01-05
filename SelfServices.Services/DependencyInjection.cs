using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfServices.Common.Interface.Repositry;
using SelfServices.Common.Interface.Services;
using SelfServices.Repositry;
using SelfServices.Repositry.Rep;
using SelfServices.Services.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEssUserService, EssUserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddRepositry(configuration);
            return services;
        }
    }
}
