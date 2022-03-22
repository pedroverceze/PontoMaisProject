using Confluent.Kafka;
using PontoMaisDomain.ClockIn.Dto;
using PontoMaisDomain.ClockIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PontoMaisWorker.Kafka
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private readonly string ipPort;
        private IClockInService _clockInService;

        public KafkaConsumer(IClockInService clockInService)
        {
            ipPort = "localhost:9092";
            _clockInService = clockInService;
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
                        //var cor = Guid.Parse(str);
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
