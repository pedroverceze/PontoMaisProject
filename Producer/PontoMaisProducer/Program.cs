// See https://aka.ms/new-console-template for more information

using PontoMaisProducer.Kafka;
using PontoMaisProducer.Kafka.Dtos;

var request = new ClockingRequest
{
    Date = DateTime.Now,
    EmployeeId = Guid.NewGuid()
};

var producer = new KafkaProducerService();

try
{
    await producer.Produce(request);

    Console.WriteLine("End of execution");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Execution with problems, exception: {ex.Message}");
    Console.ReadKey();
}



