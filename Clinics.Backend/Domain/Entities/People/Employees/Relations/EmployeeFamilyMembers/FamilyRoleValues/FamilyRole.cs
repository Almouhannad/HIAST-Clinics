using Domain.Primitives;
using Domain.Shared;

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

    public string Name { get; private set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Result<FamilyRole> Create(string name, int? id)
    {
        if (name is null)
            return Result.Failure<FamilyRole>(Errors.DomainErrors.InvalidValuesError);
        if (id is not null)
        {
            if (id < 0)
                return Result.Failure<FamilyRole>(Errors.DomainErrors.InvalidValuesError);

            return new FamilyRole(id.Value, name);
        }
        return new FamilyRole(0, name);
    }
    #endregion

    #endregion
}
