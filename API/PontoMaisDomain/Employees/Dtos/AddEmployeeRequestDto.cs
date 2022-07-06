using System;

namespace PontoMaisDomain.Employees.Dtos
{
    public class AddEmployeeRequestDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
    }
}
