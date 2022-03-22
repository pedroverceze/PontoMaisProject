using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoMaisProducer.Kafka.Dtos
{
    public class ClockingRequest
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
