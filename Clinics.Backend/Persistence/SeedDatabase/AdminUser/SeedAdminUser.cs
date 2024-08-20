
using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Identity.Users;
using Domain.Exceptions.InvalidValue;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Identity.PasswordsHashing;

namespace Persistence.SeedDatabase.AdminUser;

public class SeedAdminUser : ISeedAdminUser
{
    #region CTOR DI
    private readonly ClinicsDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public SeedAdminUser(ClinicsDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    #endregion
    public async Task Seed()
    {
        DbSet<User> users = _context.Set<User>();

        Result<User> adminUserResult = User.Create(
            "admin",
            _passwordHasher.Hash("123"),
            Roles.Admin.Name
            );
        if (adminUserResult.IsFailure)
            throw new Exception("Unable to seed admin user");

        if (users.Include(user => user.Role).Where(user => user.Role ==  Roles.Admin).ToList().Count != 1)
        {
            var adminUser = adminUserResult.Value;
            _context.Entry(adminUser.Role).State = EntityState.Unchanged;
            users.Add(adminUserResult.Value);
            await _context.SaveChangesAsync();
        }
    }
}
