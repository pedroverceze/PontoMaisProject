using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontoMaisDomain.Employees.Entities;
using PontoMaisDomain.Employees.Repositories;

namespace PontoMaisDomain.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Add(Employee employee)
        {
            //TODO: validate entity
            await _employeeRepository.Add(employee);
        }

        public Employee Get(Guid id)
        {
            return _employeeRepository.FindById(id);
        }

        public List<Employee> GetByCompanyId(Guid id)
        {
            return _employeeRepository.FindByCompany(id).ToList();
        }
    }
}
