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

            // Register AutoMapper
            services.AddAutoMapper(cfg =>{},typeof(MappingProfile).Assembly);

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            return services;
        }
    }
}
