using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Domain.Entities.People.Employees.Shared;
using Domain.Entities.People.FamilyMembers;
using Domain.Entities.People.Patients;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Employees;

public sealed class Employee : Entity
{

    #region Private ctor
    private Employee(int id) : base(id)
    {
    }

    private Employee(int id,
        Patient patient, string serialNumber, string centerStatus,
        bool isMarried = false, EmployeeAdditionalInfo? additionalInfo = null)
        : base(id)
    {
        Patient = patient;
        SerialNumber = serialNumber;
        CenterStatus = centerStatus;
        IsMarried = isMarried;
        AdditionalInfo = additionalInfo;
    }
    #endregion

    #region Properties

    public Patient Patient { get; set; } = null!;

    public EmployeeAdditionalInfo? AdditionalInfo { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string CenterStatus { get; set; } = null!;

    public bool IsMarried { get; set; }

    #region Navigations

    public ICollection<EmployeeFamilyMember> FamilyMembers { get; set; } = [];

    public ICollection<Employee> RelatedEmployees { get; set; } = [];

    public ICollection<Employee> RelatedTo { get; set; } = [];

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Employee Create(
        string firstName, string middleName, string lastName, DateOnly dateOfBirth, string gender,

        string serialNumber, string centerStatus, bool isMarried = false,

        DateOnly? startDate = null, string? academicQualification = null, string? workPhone = null, string? location = null,
        string? specialization = null, string? jobStatus = null, string? imageUrl = null
        )
    {
        #region Create patient
        Patient patient;

        try
        {
            patient = Patient.Create(firstName, middleName, lastName, dateOfBirth, gender);
        }
        catch
        {
            throw;
        }
        #endregion

        #region Check employee's required details

        if (serialNumber is null || centerStatus is null)
            throw new InvalidValuesDomainException<Employee>();

        #endregion

        #region Create additional info
        EmployeeAdditionalInfo additionalInfo;
        try
        {
            additionalInfo = EmployeeAdditionalInfo.Create(startDate, academicQualification,
                workPhone, location, specialization, jobStatus, imageUrl);
        }
        catch
        {
            throw;
        }
        #endregion

        return new Employee(0, patient, serialNumber, centerStatus, isMarried, additionalInfo);
    }
    #endregion

    #region Add family member
    public void AddFamilyMember(FamilyMember familyMember, string role)
    {
        EmployeeFamilyMember employeeFamilyMember;

        try
        {
            employeeFamilyMember = EmployeeFamilyMember.Create(Id, familyMember.Id, role);
        }
        catch
        {
            throw;
        }

        if (FamilyMembers is null)
            FamilyMembers = [];

        FamilyMembers.Add(employeeFamilyMember);
    }
    #endregion

    #region Add related employee
    public void AddRelatedEmployee( Employee employee )
    {
        // Add new employee to related
        if (RelatedEmployees is null)
            RelatedEmployees = [];
        RelatedEmployees.Add(employee);

        // Make this related to new employee
        if (employee.RelatedTo is null)
            employee.RelatedTo = [];
        employee.RelatedTo.Add(this);

    }
    #endregion

    #endregion

}


