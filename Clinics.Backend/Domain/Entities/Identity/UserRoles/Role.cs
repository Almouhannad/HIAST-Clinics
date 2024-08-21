using Domain.Primitives;

namespace Domain.Entities.Identity.UserRoles;

public sealed class Role : Entity
{
    #region Private ctor
    private Role(int id) : base(id)
    {
    }

    private Role(int id, string name) : base(id)
    {
        Name = name;
    }
    #endregion

    #region Properties
    public string Name { get; private set; } = null!;
    #endregion

    #region Methods

    #region Static factory
    internal static Role Create(int id, string name)
    {
        return new Role(id, name);
    }
    #endregion

    #endregion
}
