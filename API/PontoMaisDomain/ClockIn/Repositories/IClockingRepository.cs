using PontoMaisDomain.ClockIn.Entities;

namespace PontoMaisDomain.ClockIn.Repositories
{
    public interface IClockingRepository
    {
        Task AddOrUpdate(Clocking clocking);
        Task<Clocking> GetByDate(DateTime date);
        Task Save();

        Task<Clocking> GetByEmployee(Guid id, int day, int month, int year);
    }
}
