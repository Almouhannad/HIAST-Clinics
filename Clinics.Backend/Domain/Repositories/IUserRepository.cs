using Domain.Entities.Identity.Users;
using Domain.Entities.People.Doctors;
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

    #region Change password
    public Task<Result> ChangePassword(User user, string password);
    #endregion

    #region Change username
    public Task<Result> ChangeUserName(User user, string userName);
    #endregion

    #region Doctor users

    #region Get doctor user by user name full
    public Task<Result<DoctorUser>> GetDoctorUserByUserNameFullAsync(string userName);

    #endregion

    #region Get all doctors 
    public Task<Result<ICollection<DoctorUser>>> GetAllDoctorUsersAsync();
    #endregion

    #region Get doctor user by id
    public Task<Result<DoctorUser>> GetDoctorUserByIdAsync(int id);
    #endregion

    #region Register doctor
    public Task<Result<DoctorUser>> RegisterDoctorAsync(DoctorUser doctorUser);
    #endregion

    #region Update doctor user
    public Task<Result> UpdateDoctorUserAsync(DoctorUser doctorUser);
    #endregion

    #region Get Doctor by doctor user
    public Task<Result<Doctor>> GetDoctorByDoctorUserIdAsync(int doctorUserId);
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
