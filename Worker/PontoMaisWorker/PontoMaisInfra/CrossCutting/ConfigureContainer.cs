using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PontoMaisDomain.ClockIn.Repositories;
using PontoMaisDomain.ClockIn.Services;
using PontoMaisDomain.Companies.Repositories;
using PontoMaisDomain.Companies.Services;
using PontoMaisDomain.Employees.Repositories;
using PontoMaisDomain.Employees.Services;
using PontoMaisDomain.Kafka;
using PontoMaisInfra.EF.Repositories;

namespace PontoMaisInfra.CrossCutting
{
    public static class ConfigureContainer
    {
        public static void Configure(IServiceCollection service)
        {
            var connectionString = "Data Source=localhost;User Id=sa;Password=Pedro123;Initial Catalog=PontoMais;";

            service.AddScoped<IKafkaProducerService, KafkaProducerService>();
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
