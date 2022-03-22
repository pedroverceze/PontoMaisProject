using PontoMaisDomain.Abstract.Entities;
using PontoMaisDomain.Employees.Entities;

namespace PontoMaisDomain.Companies.Entities
{
    public class Company : BaseEntity
    {
        public Company(string name, string adress, string sector, string createdBy)
        {
            Name = name;
            Adress = adress;
            Sector = sector;
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;
        }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string Sector { get; set; }
        public IList<Employee> Employess { get; set; }
    }
}
