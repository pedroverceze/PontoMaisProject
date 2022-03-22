using Microsoft.EntityFrameworkCore;
using PontoMaisInfra.EF.Mappings;

namespace PontoMaisInfra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new ClockingEventMap());
            builder.ApplyConfiguration(new ClockingEventMap());
        }
    }
}
