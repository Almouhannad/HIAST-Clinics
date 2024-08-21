using Domain.Entities.Identity.UserRoles;
using Domain.Entities.People.Doctors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Identity.Users;

public sealed class DoctorUser : Entity
{
    #region Private ctor
    private DoctorUser(int id) : base(id)
    {
    }

    private DoctorUser(int id, User user, Doctor doctor) : base(id)
    {
        User = user;
        Doctor = doctor;
    }
    #endregion

    #region Properties
    public User User { get; private set; } = null!;
    public Doctor Doctor { get; private set; } = null!;
    #endregion

    #region Methods

    #region Static factory
    public static Result<DoctorUser> Create (
        string username, string hashedPassword, // User details

        string firstName, string middleName, string lastName // Doctor details
        )
    {
        Result<Doctor> doctorResult = Doctor.Create(firstName, middleName, lastName);
        if (doctorResult.IsFailure)
            return Result.Failure<DoctorUser>(doctorResult.Error);

        Result<User> userResult = User.Create(username, hashedPassword, Roles.Doctor.Name);
        if (userResult.IsFailure)
            return Result.Failure<DoctorUser>(userResult.Error);

        return new DoctorUser(0, userResult.Value, doctorResult.Value);
    }
    #endregion

    #endregion
}
