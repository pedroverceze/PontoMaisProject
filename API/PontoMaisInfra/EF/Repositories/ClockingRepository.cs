using Microsoft.EntityFrameworkCore;
using PontoMaisDomain.ClockIn.Entities;
using PontoMaisDomain.ClockIn.Repositories;

namespace PontoMaisInfra.EF.Repositories
{
    public class ClockingRepository : BaseRepository<Clocking>, IClockingRepository
    {
        public ClockingRepository(Context context) : base(context)
        {
        }

        public async Task AddOrUpdate(Clocking clocking)
        {
            if (Exists(clocking.Id))
            {
                _dbSet.Update(clocking);
            }
            else
            {
                await _dbSet.AddAsync(clocking);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Clocking GetByDate(DateTime date)
        {
            return FilterByDate(date).FirstOrDefault();
        }

        public IQueryable<Clocking> FilterByDate(DateTime date)
        {
            return _dbSet.Where(c => c.Day == date.Date)
            .Include(c => c.ClockingEvents);
        }

        public bool Exists(Guid id)
        {
            return _dbSet.Where(c => c.Id == id)
            .FirstOrDefault() != null;
        }

        public Clocking GetByEmployee (Guid id, int day, int month, int year)
        {
            DateTime date = new DateTime(year,month,day);

            return FilterByEmployee(id, date)
                    .FirstOrDefault();
        }

        public IQueryable<Clocking> FilterByEmployee(Guid id, DateTime date)
        {
            return _dbSet.
            Where(c => c.EmployeeId == id && c.Day == date.Date)
            .Include(c => c.ClockingEvents);
        }
    }
}
