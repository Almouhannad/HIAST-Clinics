using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.FamilyMembers;
using Domain.Primitives;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;

public sealed class EmployeeFamilyMember(int id) : Entity(id)
{
    #region Properties

    #region Employee

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    #endregion

    #region Family member

    public int FamilyMemberId { get; set; }
    public FamilyMember FamilyMember { get; set; } = null!;

    #endregion

    #region Additional

    public FamilyRole Role { get; set; } = null!;

    #endregion

    #endregion
}
