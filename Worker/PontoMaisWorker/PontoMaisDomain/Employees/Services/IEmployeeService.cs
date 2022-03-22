using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Employees.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        
        Task<Employee> Get(Guid id);

        List<Employee> GetByCompanyId(Guid id);
    }
}