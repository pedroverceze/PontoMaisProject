using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PontoMaisDomain.ClockIn.Dto;

namespace PontoMaisDomain.ClockIn.Services
{
    public interface IClockInService
    {
        Task Input(Guid employeeId);

        List<ClockingList> GetByEmployee(Guid id, int day, int month, int year);
    }
}