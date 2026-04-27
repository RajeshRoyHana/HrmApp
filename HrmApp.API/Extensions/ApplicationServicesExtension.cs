using HrmApp.Services;
using HrmApp.Services.DataContext;
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
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ICommonService, CommonService>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                    });
            });


            return services;
        }
    }
}
