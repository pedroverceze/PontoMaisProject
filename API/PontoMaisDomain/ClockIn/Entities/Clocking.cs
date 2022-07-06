using System;
using System.Collections.Generic;
using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.ClockIn.Enums;
using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.ClockIn.Entities
{
    public class Clocking : BaseEntity
    {
        public Clocking(Guid employeeId, DateTime date, Employee employee)
        {
            
            CreatedAt = DateTime.Now;
            CreatedBy = "teste";
            Day = date.Date;
            EmployeeId = employee.Id;
            ClockingEvents = new List<ClockingEvent>();
        }

        public Clocking()
        {

        }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Day { get; set; }
        public ICollection<ClockingEvent> ClockingEvents { get; set; }
    }
}
