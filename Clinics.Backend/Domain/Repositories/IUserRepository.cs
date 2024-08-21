using Domain.Entities.Identity.Users;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{

    public Task<Result<User>> GetByUserNameFullAsync(string userName);

    public Task<Result<User?>> VerifyPasswordAsync(string userName, string password);

    public Task<Result<DoctorUser>> GetDoctorUserByUserNameFullAsync(string userName);
    public Task<Result<ReceptionistUser>> GetReceptionistUserByUserNameFullAsync(string userName);
}
