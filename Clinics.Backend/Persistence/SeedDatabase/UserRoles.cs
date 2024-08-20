using Domain.Entities.Identity.UserRoles;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase;

public class UserRoles : ISeed<Role>
{
    #region CTOR DI
    private readonly ClinicsDbContext _context;

    public UserRoles(ClinicsDbContext context)
    {
        _context = context;
    }
    #endregion
    public async Task Seed()
    {
        DbSet<Role> roles = _context.Set<Role>();

        var current = await roles.ToListAsync();
        // TODO: perform deep check on all seed operations
        if (current.Count != Roles.Count)
        {
            roles.RemoveRange(current);

            roles.Add(Roles.Admin);

            roles.Add(Roles.Doctor);

            roles.Add(Roles.Receptionist);

            await _context.SaveChangesAsync();
        }
    }
}
