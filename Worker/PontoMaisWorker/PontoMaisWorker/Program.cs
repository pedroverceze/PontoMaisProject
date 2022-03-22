using PontoMaisInfra.CrossCutting;
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
