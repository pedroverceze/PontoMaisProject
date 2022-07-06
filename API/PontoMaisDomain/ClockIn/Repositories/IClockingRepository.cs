using System;
using System.Threading.Tasks;
using PontoMaisDomain.ClockIn.Entities;

namespace PontoMaisDomain.ClockIn.Repositories
{
    public interface IClockingRepository
    {
        Task AddOrUpdate(Clocking clocking);
        Clocking GetByDate(DateTime date);
        Task Save();
        Clocking GetByEmployee(Guid id, int day, int month, int year);
    }
}
