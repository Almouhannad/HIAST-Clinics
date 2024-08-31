using Domain.Entities.Identity.UserRoles;
using Domain.Entities.People.Shared;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Identity.Users;

public sealed class ReceptionistUser : Entity
{
    #region Private ctor
    private ReceptionistUser(int id) : base(id)
    {
    }

    private ReceptionistUser(int id, User user, PersonalInfo personalInfo) : base(id)
    {
        User = user;
        PersonalInfo = personalInfo;
    }
    #endregion

    #region Properties
    public User User { get; private set; } = null!;
    public PersonalInfo PersonalInfo { get; private set; } = null!;
    #endregion

    #region Methods

    #region Static factory
    public static Result<ReceptionistUser> Create(
        string userName, string hashedPassword,

        string firstName, string middleName, string lastName
        )
    {
        Result<PersonalInfo> personalInfoResult = PersonalInfo.Create(firstName, middleName, lastName);
        if (personalInfoResult.IsFailure)
            return Result.Failure<ReceptionistUser>(personalInfoResult.Error);

        Result<User> userResult = User.Create(userName, hashedPassword, UsersRoles.Receptionist.Name);
        if (userResult.IsFailure)
            return Result.Failure<ReceptionistUser>(userResult.Error);

        return new ReceptionistUser(0, userResult.Value, personalInfoResult.Value);

    }
    #endregion

    #endregion
}
