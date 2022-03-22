using Confluent.Kafka;
using PontoMaisDomain.ClockIn.Dto;
using System.Text.Json;

namespace PontoMaisDomain.Kafka
{
    public class KafkaProducerService : IKafkaProducerService
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

            try
            {

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
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
