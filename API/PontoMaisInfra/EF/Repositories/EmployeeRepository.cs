using System.Linq;
using PontoMaisDomain.Employees.Entities;
using PontoMaisDomain.Employees.Repositories;

namespace PontoMaisInfra.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        { }

        public async Task Add(Employee employee)
        {
            await _dbSet.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> FindByCompany(Guid id)
        {
            return _dbSet.Where(c => c.CompanyId == id).ToList();
        }

        public Employee FindById(Guid id)
        {
            return Filter(id).First();
        }

        private IQueryable<Employee> Filter(Guid id)
        {
            return _dbSet.Where(e => e.Id.Equals(id));
        }
    }
}
