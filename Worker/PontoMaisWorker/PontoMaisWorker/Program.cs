using Microsoft.EntityFrameworkCore;
using PontoMaisDomain.ClockIn.Repositories;
using PontoMaisDomain.ClockIn.Services;
using PontoMaisDomain.Companies.Repositories;
using PontoMaisDomain.Companies.Services;
using PontoMaisDomain.Employees.Repositories;
using PontoMaisDomain.Employees.Services;
using PontoMaisInfra;
using PontoMaisInfra.CrossCutting;
using PontoMaisInfra.EF.Repositories;
using PontoMaisWorker;
using PontoMaisWorker.Kafka;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
    {
        services.AddHostedService<Worker>();
        services.AddScoped<IKafkaConsumer, KafkaConsumer>();

        ConfigureContainer.Configure(services);
    })
    .Build();

await host.RunAsync();
