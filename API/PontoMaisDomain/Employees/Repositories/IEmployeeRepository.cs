using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Employees.Repositories
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Employee FindById(Guid id);
        IEnumerable<Employee> FindByCompany(Guid id);
    }
}
