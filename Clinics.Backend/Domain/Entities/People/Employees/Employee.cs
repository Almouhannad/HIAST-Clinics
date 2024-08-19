using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.Employees.Shared;
using Domain.Entities.People.FamilyMembers;
using Domain.Entities.People.Patients;
using Domain.Entities.People.Shared.GenderValues;
using Domain.Primitives;
using Domain.Shared;

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

    public Patient Patient { get; private set; } = null!;

    public EmployeeAdditionalInfo? AdditionalInfo { get; private set; }

    public string SerialNumber { get; private set; } = null!;

    public string CenterStatus { get; private set; } = null!;

    public bool IsMarried { get; private set; }

    #region Navigations

    #region Family members
    private readonly List<EmployeeFamilyMember> _familyMembers = [];
    public IReadOnlyCollection<EmployeeFamilyMember> FamilyMembers => _familyMembers;

    #endregion

    #region Related employees
    private readonly List<Employee> _relatedEmployees = [];
    public IReadOnlyCollection<Employee> RelatedEmployees => _relatedEmployees;

    private readonly List<Employee> _relatedTo = [];
    public IReadOnlyCollection<Employee> RelatedTo => _relatedTo;

    #endregion


    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Employee> Create(
        string firstName, string middleName, string lastName, DateOnly dateOfBirth, string gender,

        string serialNumber, string centerStatus, bool isMarried = false,

        DateOnly? startDate = null, string? academicQualification = null, string? workPhone = null, string? location = null,
        string? specialization = null, string? jobStatus = null, string? imageUrl = null
        )
    {
        #region Create patient
        Result<Patient> patient = Patient.Create(firstName, middleName, lastName, dateOfBirth, gender);
        if (patient.IsFailure)
            return Result.Failure<Employee>(patient.Error);
        #endregion

        #region Check employee's required details

        if (serialNumber is null || centerStatus is null)
            return Result.Failure<Employee>(Errors.DomainErrors.InvalidValuesError);

        #endregion

        #region Create additional info

        EmployeeAdditionalInfo? additionalInfo = EmployeeAdditionalInfo.Create(
            startDate, academicQualification, workPhone,
            location, specialization, jobStatus, imageUrl);


        #endregion

        return new Employee(0, patient.Value, serialNumber, centerStatus, isMarried, additionalInfo);
    }
    #endregion

    #region Add family member
    public Result AddFamilyMember(FamilyMember familyMember, string role)
    {

        #region Create family member to attach
        Result<EmployeeFamilyMember> employeeFamilyMember =
            EmployeeFamilyMember.Create(Id, familyMember.Id, role);
        if (employeeFamilyMember.IsFailure)
            return Result.Failure(employeeFamilyMember.Error);
        #endregion

        #region Check valid relation

        if (role == FamilyRoles.Husband.Name && Patient.Gender == Genders.Male)
            return Result.Failure(Errors.DomainErrors.InvalidHusbandRole);

        if (role == FamilyRoles.Wife.Name && Patient.Gender == Genders.Female)
            return Result.Failure(Errors.DomainErrors.InvalidWifeRole);

        #endregion

        #region Check duplicate
        if (FamilyMembers.Where(fm => fm.FamilyMember == familyMember).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.RelationAlreadyExist);
        #endregion

        _familyMembers.Add(employeeFamilyMember.Value);
        IsMarried = true;
        return Result.Success();
    }
    #endregion

    #region Add related employee
    public Result AddRelatedEmployee(Employee employee)
    {
        #region Check valid relation

        if (Patient.Gender == Genders.Male && employee.Patient.Gender == Genders.Male)
            return Result.Failure(Errors.DomainErrors.InvalidHusbandRole);

        if (Patient.Gender == Genders.Female && employee.Patient.Gender == Genders.Female)
        {
            return Result.Failure(Errors.DomainErrors.InvalidWifeRole);
        }

        #endregion

        #region Check duplicate

        if (RelatedEmployees.Where(re => re == employee).ToList().Count > 0
            || RelatedTo.Where(rt => rt == employee).ToList().Count > 0
            )
            return Result.Failure(Errors.DomainErrors.RelationAlreadyExist);

        #endregion

        _relatedEmployees.Add(employee);
        IsMarried = true;
        return Result.Success();
    }
    #endregion

    #endregion

}


