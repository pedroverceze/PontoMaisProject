using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.Companies.Entities;

namespace PontoMaisDomain.Employees.Entities
{
    public class Employee : BaseEntity
    {
        public Employee(string name, int age, string role, Guid companyId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Role = role;
            CompanyId = companyId;
            CreatedAt = DateTime.Now;
            CreatedBy = "teste";
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
