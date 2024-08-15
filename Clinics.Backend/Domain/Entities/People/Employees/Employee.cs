using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Domain.Entities.People.Employees.Shared;
using Domain.Entities.People.Patients;
using Domain.Primitives;

namespace Domain.Entities.People.Employees;

public sealed class Employee(int id) : Entity(id)
{
    #region Properties

    public Patient Patient { get; set; } = null!;

    public EmployeeAdditionalInfo? AdditionalInfo { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string CenterStatus { get; set; } = null!;

    public bool IsMarried { get; set; } = false;

    #region Navigations

    public ICollection<EmployeeFamilyMember> FamilyMembers { get; set; } = [];

    public ICollection<Employee> RelatedEmployees { get; set; } = [];

    public ICollection<Employee> RelatedTo { get; set; } = [];

    #endregion

    #endregion

}


