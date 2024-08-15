using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public partial class ClinicsDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: Use options pattern
        optionsBuilder.UseSqlServer("server=.\\;database=Clinics;Trusted_Connection=True; Encrypt=False;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicsDbContext).Assembly);
    }
}
