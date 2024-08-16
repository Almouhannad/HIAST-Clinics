using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.FamilyMembers;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    #region Methods

    #region Static factory
    public static EmployeeFamilyMember Create(int employeeId, int familyMemberId, string role)
    {
        if (employeeId <= 0 || familyMemberId <= 0 || role is null)
            throw new InvalidValuesDomainException<EmployeeFamilyMember>();

        #region Check role
        FamilyRole? selectedRole;

        FamilyRole husband = FamilyRoles.Husband;
        FamilyRole wife = FamilyRoles.Wife;
        FamilyRole son = FamilyRoles.Son;
        FamilyRole daughter = FamilyRoles.Daughter;

        if (role == husband.Name)
            selectedRole = husband;
        else if (role == wife.Name)
            selectedRole = wife;
        else if (role == son.Name)
            selectedRole = son;
        else if (role == daughter.Name)
            selectedRole = daughter;
        else selectedRole = null;

        if (selectedRole is null)
            throw new InvalidValuesDomainException<FamilyRole>();

        #endregion

        return new EmployeeFamilyMember(0, employeeId, familyMemberId, selectedRole);
    }
    #endregion

    #endregion

}
