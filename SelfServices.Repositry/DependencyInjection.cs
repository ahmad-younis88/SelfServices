using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfServices.Common.Generic;
using SelfServices.Common.Interface.Repositry;
using SelfServices.Repositry.Rep;

namespace SelfServices.Repositry
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositry(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext.AppContext>(options =>
                         options.UseSqlServer(
                             configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IDapper, Dapper>();
            services.AddScoped<ICompanyRepositry, CompanyRepositry>();
            services.AddScoped<IEssUserRepositry, EssUserRepositry>();
            services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();
            services.AddScoped<ISettingRepositry, SettingRepositry>();
            return services;
        }
    }
}
