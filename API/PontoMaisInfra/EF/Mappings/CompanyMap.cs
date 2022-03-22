using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoMaisDomain.Companies.Entities;

namespace PontoMaisInfra.EF.Mappings
{
    internal class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Employess)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
