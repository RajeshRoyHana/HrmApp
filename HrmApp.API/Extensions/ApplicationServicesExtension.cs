using HrmApp.Repositories;
using HrmApp.Repositories.DataContext;
using HrmApp.Repositories.Interfaces;
using HrmApp.Services;
using HrmApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrmApp.API.Extensions
{
    public static class ApplicationServicesExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
          IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ICommonRepository, CommonRepository>();


            return services;
        }
    }
}
