using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.FamilyMembers;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;

public sealed class EmployeeFamilyMember : Entity
{
    #region Private ctor
    private EmployeeFamilyMember(int id) : base(id)
    {
    }
    private EmployeeFamilyMember(int id, int employeeId, int familyMemberId, FamilyRole role) : base(id)
    {
        EmployeeId = employeeId;
        FamilyMemberId = familyMemberId;
        Role = role;
    }
    #endregion

    #region Properties

    #region Employee

    public int EmployeeId { get; private set; }
    public Employee Employee { get; private set; } = null!;

    #endregion

    #region Family member

    public int FamilyMemberId { get; private set; }
    public FamilyMember FamilyMember { get; private set; } = null!;

    #endregion

    #region Additional

    public FamilyRole Role { get; private set; } = null!;

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<EmployeeFamilyMember> Create(int employeeId, int familyMemberId, string role)
    {
        if (employeeId <= 0 || familyMemberId <= 0 || role is null)
            return Result.Failure<EmployeeFamilyMember>(Errors.DomainErrors.InvalidValuesError);

        #region Check role
        Result<FamilyRole> selectedRole = new(null, false, Errors.DomainErrors.InvalidValuesError);

        FamilyRole husband = FamilyRoles.Husband;
        FamilyRole wife = FamilyRoles.Wife;
        FamilyRole son = FamilyRoles.Son;
        FamilyRole daughter = FamilyRoles.Daughter;

        if (role == husband.Name)
            selectedRole = Result.Success<FamilyRole>(husband);
        else if (role == wife.Name)
            selectedRole = Result.Success<FamilyRole>(wife);
        else if (role == son.Name)
            selectedRole = Result.Success<FamilyRole>(son);
        else if (role == daughter.Name)
            selectedRole = Result.Success<FamilyRole>(daughter);

        if (selectedRole.IsFailure)
            return Result.Failure<EmployeeFamilyMember>(Errors.DomainErrors.InvalidValuesError);

        #endregion

        return new EmployeeFamilyMember(0, employeeId, familyMemberId, selectedRole.Value);
    }
    #endregion

    #endregion

}
