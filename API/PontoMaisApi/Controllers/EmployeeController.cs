using Microsoft.AspNetCore.Mvc;
using PontoMaisDomain.Employees.Dtos;
using PontoMaisDomain.Employees.Entities;
using PontoMaisDomain.Employees.Services;
using System;

namespace PontoMaisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEMployee([FromBody] AddEmployeeRequestDto request)
        {
            var employee = new Employee(request.Name, request.Age, request.Role, request.CompanyId);

            await _employeeService.Add(employee);

            return Created(nameof(AddEMployee) ,employee);
        }

        [HttpGet]
        [Route("GetByCompany/{companyId}")]
        public IActionResult GetEmployeeByCompany(Guid companyId){
            var employees = _employeeService.GetByCompanyId(companyId);

            return Ok(employees);
        }
    }
}
