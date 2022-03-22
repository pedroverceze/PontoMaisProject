using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoMaisDomain.ClockIn.Entities;

namespace PontoMaisInfra.EF.Mappings
{
    internal class ClockingMap : IEntityTypeConfiguration<Clocking>
    {
        public void Configure(EntityTypeBuilder<Clocking> builder)
        {
            builder.HasKey(c => new { c.Id, c.EmployeeId, c.Day});
            builder.HasMany(c => c.ClockingEvents)
                .WithOne(c => c.Clocking)
                .HasForeignKey(c => c.ClockingId);
        }
    }
}
