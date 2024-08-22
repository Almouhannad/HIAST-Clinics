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

    #region Available username
    public Task<Result<bool>> IsUserNameAvailableAsunc(string userName);
    #endregion

    #region Doctor users

    #region Get doctor user by user name full
    public Task<Result<DoctorUser>> GetDoctorUserByUserNameFullAsync(string userName);

    #endregion

    #region Get all doctors 
    public Task<Result<ICollection<DoctorUser>>> GetAllDoctorUsersAsync();
    #endregion

    #region Register doctor
    public Task<Result<DoctorUser>> RegisterDoctorAsync(DoctorUser doctorUser);
    #endregion

    #endregion

    #region Receptionists users

    #region Get receptionist user by user name full
    public Task<Result<ReceptionistUser>> GetReceptionistUserByUserNameFullAsync(string userName);

    #endregion

    #region Get all Receptionist Users
    public Task<Result<ICollection<ReceptionistUser>>> GetAllReceptionistUsersAsync();
    #endregion

    #region Register receptionist
    public Task<Result<ReceptionistUser>> RegisterReceptionistAsync(ReceptionistUser receptionistUser);

    #endregion

    #endregion


}
