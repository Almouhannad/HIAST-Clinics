using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Identity.PasswordsHashing;
using Persistence.Repositories.Base;
using Persistence.Repositories.Users.Specifications;

namespace Persistence.Repositories.Users;

public class UserRepository : Repositroy<User>, IUserRepository
{
    #region Ctor DI
    private readonly IPasswordHasher _passwordHasher;
    public UserRepository(ClinicsDbContext context, IPasswordHasher passwordHasher) : base(context)
    {
        _passwordHasher = passwordHasher;
    }
    #endregion

    #region Create method
    public override Task<Result<User>> CreateAsync(User entity)
    {
        _context.Entry(entity.Role).State = EntityState.Unchanged;
        return base.CreateAsync(entity);
    }
    #endregion

    #region Get by username
    public async Task<Result<User>> GetByUserNameFullAsync(string userName)
    {
        var query = ApplySpecification(new FullUserSpecification(user => user.UserName == userName));

        var result = await query.ToListAsync();

        if (result.Count == 0)
        {
            return Result.Failure<User>(IdentityErrors.NotFound);
        }
        return result.First();
    }
    #endregion

    #region Verify password
    public async Task<Result<User?>> VerifyPasswordAsync(string userName, string password)
    {
        var userResult = await GetByUserNameFullAsync(userName);
        if (userResult.IsFailure)
            return Result.Failure<User?>(userResult.Error);

        if (!_passwordHasher.Verify(password, userResult.Value.HashedPassword))
            return Result.Success<User?>(null);

        return Result.Success<User?>(userResult.Value);

    }
    #endregion

    #region Get doctor user by user name full
    public async Task<Result<DoctorUser>> GetDoctorUserByUserNameFullAsync(string username)
    {
        // This is a multi level query, so using specification pattern in this case is useless
        var query
            = _context.Set<DoctorUser>()
            .Include(doctroUser => doctroUser.User)
                .ThenInclude(user => user.Role)
            .Where(doctorUser => doctorUser.User.UserName == username)
            .Include(doctorUser => doctorUser.Doctor)
                .ThenInclude(doctor => doctor.PersonalInfo);
        var result = await query.ToListAsync();

        if (result.Count != 1)
            return Result.Failure<DoctorUser>(IdentityErrors.NotFound);

        return result.First();
    }
    #endregion

    #region Get receptionist user by user name full
    public async Task<Result<ReceptionistUser>> GetReceptionistUserByUserNameFullAsync(string username)
    {
        var query
            = _context.Set<ReceptionistUser>()
            .Include(receptionistUser => receptionistUser.User)
                .ThenInclude(user => user.Role)
            .Where(receptionistUser => receptionistUser.User.UserName == username)
            .Include(receptionistUser => receptionistUser.PersonalInfo);

        var result = await query.ToListAsync();

        if (result.Count != 1)
            return Result.Failure<ReceptionistUser>(IdentityErrors.NotFound);

        return result.First();
    }
    #endregion
}
