using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Users;

public class UserRepository : Repositroy<User>, IUserRepository
{
    #region Ctor DI
    public UserRepository(ClinicsDbContext context) : base(context)
    {
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

}
