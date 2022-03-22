using Microsoft.Extensions.DependencyInjection;
using PontoMaisWorker.Kafka;

namespace PontoMaisWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger,
                    IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using(var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<IKafkaConsumer>();
                    service.Consume("topic-teste-kafdrop", stoppingToken).GetAwaiter();
                }
                //_kafkaConsumer.Consume("topic-teste-kafdrop", stoppingToken).GetAwaiter();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}