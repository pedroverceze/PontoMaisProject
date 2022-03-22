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

        public async Task Input(ClockingRequest request, Guid correlationId)
        {
            _logger.LogInformation(correlationId.ToString(), request);

            Clocking clocking;

            var employee = await _employeeRepository.FindById(request.EmployeeId);

            //TODO: problema aqui
            clocking = await _clockingRepository.GetByDate(request.Date);

            if (clocking is not null)
            {
                if(clocking.ClockingEvents == null)
                {
                    clocking.ClockingEvents = new List<ClockingEvent>();
                }
            }
            else
            {
                clocking = new Clocking(request.EmployeeId, request.Date, employee);
            }

            var entry = GetEntryType(clocking);

            var clockingEvent = new ClockingEvent
                {
                    Id = Guid.NewGuid(),
                    ClockingId = clocking.Id,
                    CreatedAt = request.Date,
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
            if(clocking.ClockingEvents.Count() == 0){
                return EntryType.Entrance;
            }

            if(clocking.ClockingEvents.OrderBy(c => c.EventNu).Last().EntryType.Equals(EntryType.Entrance)){
                return EntryType.Exit;
            }

            return EntryType.Entrance;
        }
    }
}
