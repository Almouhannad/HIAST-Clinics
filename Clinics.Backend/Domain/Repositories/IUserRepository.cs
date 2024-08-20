using Domain.Entities.Identity.Users;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<Result<User>> GetByUserNameFullAsync(string userName);
}
