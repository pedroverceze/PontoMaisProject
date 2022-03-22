using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoMaisDomain.Employees.Entities;

namespace PontoMaisInfra.EF.Mappings
{
    internal class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Company)
                .WithMany(e => e.Employess)
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
