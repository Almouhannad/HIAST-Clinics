using Domain.Entities.Identity.UserRoles;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase;

public class UserRoles : ISeed<UserRole>
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
        DbSet<UserRole> roles = _context.Set<UserRole>();

        var current = await roles.ToListAsync();
        // TODO: perform deep check on all seed operations
        if (current.Count != UsersRoles.Count)
        {
            roles.RemoveRange(current);

            roles.Add(UsersRoles.Admin);

            roles.Add(UsersRoles.Doctor);

            roles.Add(UsersRoles.Receptionist);

            await _context.SaveChangesAsync();
        }
    }
}
