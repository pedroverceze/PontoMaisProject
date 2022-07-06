using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PontoMaisDomain.ClockIn.Dto;
using PontoMaisDomain.ClockIn.Entities;
using PontoMaisDomain.ClockIn.Enums;
using PontoMaisDomain.ClockIn.Repositories;
using PontoMaisDomain.Employees.Repositories;

namespace PontoMaisDomain.ClockIn.Services
{
    public class ClockInService : IClockInService
    {
        private IClockingRepository _clockingRepository;
        private IEmployeeRepository _employeeRepository;
        private ILogger<ClockInService> _logger;

        public ClockInService(IClockingRepository clockingRepository,
                              IEmployeeRepository employeeRepository,
                              ILogger<ClockInService> logger)
        {
            _clockingRepository = clockingRepository;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public List<ClockingList> GetByEmployee(Guid id, int day, int month, int year)
        {
            List<ClockingList> list = new List<ClockingList>();
            var clock = _clockingRepository.GetByEmployee(id, day, month, year);

            if(clock is null){
                return new List<ClockingList>();
            }

            foreach(var item in clock.ClockingEvents){

                var entrype = ((double)item.EntryType) == 1 ? "Entrada" : "Saida";

                list.Add(new ClockingList{
                    EntryType =  entrype,
                    Day = item.EventTime.Day,
                    Mounth = item.EventTime.Month,
                    Hour = item.EventTime.TimeOfDay
                });
            }

            return list;
        }

        public async Task Input(Guid employeeId)
        {
            Clocking clocking;
            var date = DateTime.Now.Date;

            _logger.LogInformation(employeeId.ToString());

            var employee = _employeeRepository.FindById(employeeId);

            clocking = _clockingRepository.GetByDate(date);

            if (clocking is not null)
            {
                if(clocking.ClockingEvents == null)
                {
                    clocking.ClockingEvents = new List<ClockingEvent>();
                }
            }
            else
            {
                clocking = new Clocking(employeeId, DateTime.Now.Date, employee);
            }

            var entry = GetEntryType(clocking);

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

            await _clockingRepository.AddOrUpdate(clocking);
            await _clockingRepository.Save();
        }

        private EntryType GetEntryType(Clocking clocking)
        {
            var IsThereNoEvents = clocking.ClockingEvents.Count() == 0;

            if(IsThereNoEvents){
                return EntryType.Entrance;
            }

            if(clocking.ClockingEvents
            .OrderBy(c => c.EventNu).Last()
            .EntryType.Equals(EntryType.Entrance)){
                return EntryType.Exit;
            }

            return EntryType.Entrance;
        }
    }
}
