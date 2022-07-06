using System;
using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.ClockIn.Enums;

namespace PontoMaisDomain.ClockIn.Entities
{
    public class ClockingEvent : BaseEntity
    {
        public EntryType EntryType { get; set; }
        public DateTime EventTime { get; set; }
        public int EventNu { get; set; }
        public Guid ClockingId { get; set; }
        public Clocking Clocking { get; set; }
    }
}
