namespace PontoMaisWorker.Kafka
{
    public interface IKafkaConsumer
    {
        Task Consume(string topicName, CancellationToken cancellationToken);
    }
}