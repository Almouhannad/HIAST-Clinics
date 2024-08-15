using Domain.Primitives;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;

public sealed class FamilyRole(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #endregion
}
