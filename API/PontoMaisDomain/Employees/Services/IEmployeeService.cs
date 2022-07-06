using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Employees.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        
        Employee Get(Guid id);

        List<Employee> GetByCompanyId(Guid id);
    }
}