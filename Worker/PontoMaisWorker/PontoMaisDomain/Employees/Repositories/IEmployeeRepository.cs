using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<Employee> FindById(Guid id);
        IEnumerable<Employee> FindByCompany(Guid id);
    }
}
