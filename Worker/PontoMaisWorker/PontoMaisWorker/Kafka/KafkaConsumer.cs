using Confluent.Kafka;
using PontoMaisDomain.ClockIn.Dto;
using PontoMaisDomain.ClockIn.Services;
using System.Text.Json;

namespace PontoMaisWorker.Kafka
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private readonly string ipPort;
        private IClockInService _clockInService;
        private IConfiguration _configuration;

        public KafkaConsumer(IClockInService clockInService, IConfiguration configuration)
        {
            _configuration = configuration;
            
            _clockInService = clockInService;
            ipPort = _configuration["ipPort"];
        }

        public Task Consume(string topicName, CancellationToken cancellationToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "ponto_mais",
                BootstrapServers = ipPort,
                EnableAutoCommit = false,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using(var builder = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                builder.Subscribe(topicName);

                try
                {
                    while (true)
                    {
                        var consumer = builder.Consume(cancellationToken);
                        var obj = JsonSerializer.Deserialize<ClockingRequest>(consumer.Message.Value);
                        var header = consumer.Message.Headers.GetLastBytes("correlationId");
                        var correlationId = new Guid(header);  
                        if (obj is not null)
                        {
                            _clockInService.Input(obj, correlationId);
                        }
                        
                        Console.WriteLine($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    builder.Close();
                }

                return Task.CompletedTask;
            }
        }
    }
}
