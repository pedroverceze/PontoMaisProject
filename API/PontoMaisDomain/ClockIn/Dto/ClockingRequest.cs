using System;

namespace PontoMaisDomain.ClockIn.Dto
{
    public class ClockingRequest
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
