using Domain.Entities.Identity.Users;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{

    public Task<Result<User>> GetByUserNameFullAsync(string userName);

    #region Verify password
    public Task<Result<User?>> VerifyPasswordAsync(string userName, string password);
    #endregion

    #region Get doctor user by user name full
    public Task<Result<DoctorUser>> GetDoctorUserByUserNameFullAsync(string userName);

    #endregion

    #region Get receptionist user by user name full
    public Task<Result<ReceptionistUser>> GetReceptionistUserByUserNameFullAsync(string userName);

    #endregion

    #region Register doctor
    public Task<Result<DoctorUser>> RegisterDoctorAsync(DoctorUser doctorUser);
    #endregion

    #region Register receptionist
    public Task<Result<ReceptionistUser>> RegisterReceptionistAsync(ReceptionistUser receptionistUser);

    #endregion

}
