using PontoMaisDomain.ClockIn.Entities;
using PontoMaisDomain.ClockIn.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoMaisDomain.ClockIn.Extensions
{
    public static class ClockingExtension
    {
        public static void CreateClockingEvent(this Clocking clocking, DateTime date, EntryType entry)
        {
            var clockingEvent = new ClockingEvent
            {
                Id = Guid.NewGuid(),
                ClockingId = clocking.Id,
                CreatedAt = date,
                EventTime = DateTime.Now,
                EventNu = clocking.ClockingEvents.Count() == 0 ? 1 : clocking.ClockingEvents.Last().EventNu + 1,
                EntryType = entry,
                CreatedBy = "teste"
            };

            clocking.ClockingEvents.Add(clockingEvent);
        }
    }
}
