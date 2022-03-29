using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoMaisDomain.ClockIn.Entities;

namespace PontoMaisInfra.EF.Mappings
{
    internal class ClockingEventMap : IEntityTypeConfiguration<ClockingEvent>
    {
        public void Configure(EntityTypeBuilder<ClockingEvent> builder)
        {
            builder.HasKey(k => new { k.Id, k.EventNu });


            builder.HasOne(c => c.Clocking)
                .WithMany(c => c.ClockingEvents)
                .HasForeignKey(c => c.ClockingId);
        }
    }
}
