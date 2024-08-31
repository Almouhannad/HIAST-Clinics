
using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Identity.Users;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Identity.PasswordsHashing;

namespace Persistence.SeedDatabase.AdminUser;

public class SeedUsers : ISeedUsers
{
    #region CTOR DI
    private readonly ClinicsDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public SeedUsers(ClinicsDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    #endregion
    public async Task Seed()
    {

        var currentCount = _context.Set<User>().ToList().Count;
        if (currentCount == 0)
        {
            #region Seed admin
            Result<User> adminUserResult = User.Create(
                "admin",
                _passwordHasher.Hash("123"),
                UsersRoles.Admin.Name
                );
            if (adminUserResult.IsFailure)
                throw new Exception("Unable to seed admin user");

            var adminUser = adminUserResult.Value;
            _context.Entry(adminUser.Role).State = EntityState.Unchanged;
            _context.Set<User>().Add(adminUserResult.Value);

            #endregion

            #region Seed doctor
            var doctorUserCreateResult = DoctorUser.Create(
                "doctor",
                _passwordHasher.Hash("123"),
                "محمد",
                "صالح",
                "التركي"
                );
            if (doctorUserCreateResult.IsFailure)
                throw new Exception("Unable to seed doctor user");
            var doctorUser = doctorUserCreateResult.Value;
            _context.Entry(doctorUser.User.Role).State = EntityState.Unchanged;
            _context.Entry(doctorUser.Doctor.Status).State = EntityState.Unchanged;
            _context.Set<DoctorUser>().Add(doctorUser);

            #endregion

            #region Seed receptionist
            var receptionistUserCreateResult = ReceptionistUser.Create(
                "receptionist",
                _passwordHasher.Hash("123"),
                "موفق",
                "سامي",
                "الحسين"
                );
            if (receptionistUserCreateResult.IsFailure)
                throw new Exception("Unable to seed receptionist user");
            var receptionistUser = receptionistUserCreateResult.Value;
            _context.Entry(receptionistUser.User.Role).State = EntityState.Unchanged;
            _context.Set<ReceptionistUser>().Add(receptionistUser);

            #endregion

            await _context.SaveChangesAsync();
        }


    }
}
