using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public partial class ClinicsDbContext : DbContext
{
    public ClinicsDbContext(DbContextOptions<ClinicsDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicsDbContext).Assembly);
    }
}
