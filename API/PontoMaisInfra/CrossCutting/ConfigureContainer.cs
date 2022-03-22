using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PontoMaisDomain.ClockIn.Repositories;
using PontoMaisDomain.ClockIn.Services;
using PontoMaisDomain.Companies.Repositories;
using PontoMaisDomain.Companies.Services;
using PontoMaisDomain.Employees.Repositories;
using PontoMaisDomain.Employees.Services;
using PontoMaisInfra.EF.Repositories;

namespace PontoMaisInfra.CrossCutting
{
    public static class ConfigureContainer
    {
        public static void Configure(IServiceCollection service, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("pontoMais");

            service.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString)
            );

            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IClockInService, ClockInService>();
            service.AddScoped<IClockingRepository, ClockingRepository>();
        }
    }
}
