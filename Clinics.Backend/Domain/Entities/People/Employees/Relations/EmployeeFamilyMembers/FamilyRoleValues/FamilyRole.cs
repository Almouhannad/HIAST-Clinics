using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;

public sealed class FamilyRole : Entity
{

    #region Private ctor
    private FamilyRole(int id) : base(id)
    {
    }

    private FamilyRole(int id, string name) : base(id)
    {
        Name = name;
    }
    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static FamilyRole Create(string name, int? id)
    {
        if (name is null)
            throw new InvalidValuesDomainException<FamilyRole>();
        if (id is not null)
        {
            if (id < 0)
                throw new InvalidValuesDomainException<FamilyRole>();

            return new FamilyRole(id.Value, name);
        }
        return new FamilyRole(0, name);
    }
    #endregion

    #endregion
}
