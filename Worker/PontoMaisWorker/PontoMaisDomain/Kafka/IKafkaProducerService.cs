using PontoMaisDomain.ClockIn.Dto;

namespace PontoMaisDomain.Kafka
{
    public interface IKafkaProducerService
    {
        Task Produce(ClockingRequest msg);
    }
}