using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontoMaisDomain.ClockIn.Enums;

namespace PontoMaisDomain.ClockIn.Dto
{
    public class ClockingList
    {
        public int Day { get; set; }
        public string EntryType { get; set; }
        public TimeSpan Hour { get; set; }
    }
}