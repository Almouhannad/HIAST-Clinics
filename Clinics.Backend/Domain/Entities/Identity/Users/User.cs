using Domain.Entities.Identity.UserRoles;
using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Identity.Users;

public sealed class User : Entity
{
    #region Private ctor
    private User(int id) : base(id)
    {
    }

    private User(int id, string userName, string hashedPassword, Role role) : base(id)
    {
        UserName = userName;
        HashedPassword = hashedPassword;
        Role = role;
    }
    #endregion

    #region Properties
    public string UserName { get; private set; } = null!;
    public string HashedPassword { get; private set; } = null!;
    public Role Role { get; private set; } = null!;
    #endregion

    #region Methods

    #region Static factory
    public static Result<User> Create(string userName, string hashedPassword, string role)
    {
        if (userName is null || hashedPassword is null || role is null)
        {
            return Result.Failure<User>(DomainErrors.InvalidValuesError);
        }

        #region Check role
        Result<Role> selectedRole = Result.Failure<Role>(IdentityErrors.InvalidRole);
        List<Role> roles = Roles.GetAll();
        foreach (Role roleItem in roles)
        {
            if (roleItem.Name == role)
                selectedRole = roleItem;
        }
        if (selectedRole.IsFailure)
            return Result.Failure<User>(selectedRole.Error);
        #endregion

        return new User(0, userName, hashedPassword, selectedRole.Value);
    }
    #endregion

    #region Set HASHED password
    public Result SetHashedPassword(string hashedPassword)
    {
        if (hashedPassword is null)
            return Result.Failure(DomainErrors.InvalidValuesError);

        HashedPassword = hashedPassword;
        return Result.Success();
    }
    #endregion

    #region Update userName
    public Result UpdateUserName(string userName)
    {
        if (userName is null)
            return Result.Failure(DomainErrors.InvalidValuesError);
        UserName = userName;
        return Result.Success();
    }
    #endregion

    #endregion
}
