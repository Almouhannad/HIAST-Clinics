using Domain.Primitives;

namespace Domain.Entities.Identity.UserRoles;

public sealed class UserRole : Entity
{
    #region Private ctor
    private UserRole(int id) : base(id)
    {
    }

    private UserRole(int id, string name) : base(id)
    {
        Name = name;
    }
    #endregion

    #region Properties
    public string Name { get; private set; } = null!;
    #endregion

    #region Methods

    #region Static factory
    internal static UserRole Create(int id, string name)
    {
        return new UserRole(id, name);
    }
    #endregion

    #endregion
}
