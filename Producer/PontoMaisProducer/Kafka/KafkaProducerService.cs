using Confluent.Kafka;
using PontoMaisProducer.Kafka.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PontoMaisProducer.Kafka
{
    public class KafkaProducerService
    {
        private readonly string ipPort;
        private readonly string topicName;

        public KafkaProducerService()
        {
            ipPort = "localhost:9092";
            topicName = "topic-teste-kafdrop";
        }

        public async Task Produce(ClockingRequest msg)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = ipPort
            };

            var msgTxt = JsonSerializer.Serialize(msg);

            using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
            {
                var result = await producer.ProduceAsync(
                    topicName,
                    new Message<Null, string>
                    {
                        Value = msgTxt,
                        Headers = new Headers{
                                new Header("correlationId", Guid.NewGuid().ToByteArray())
                        }
                    });
            }

            Console.WriteLine($"Mensagem produzida no topico: {topicName}");
        }
    }
}
