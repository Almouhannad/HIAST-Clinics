using Domain.Entities.People.Doctors.Shared;
using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Entities.People.Shared;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.Doctors;

public sealed class Doctor : Entity
{
    #region Private ctor
    private Doctor(int id) : base(id)
    {
    }

    private Doctor(int id, PersonalInfo personalInfo) : base(id)
    {
        PersonalInfo = personalInfo;
        Status = DoctorStatuses.Available;
    }
    #endregion

    #region Properties

    public PersonalInfo PersonalInfo { get; private set; } = null!;

    public DoctorStatus Status { get; private set; } = null!;

    #region Navigations

    #region Phones
    private readonly List<DoctorPhone> _phones = [];
    public IReadOnlyCollection<DoctorPhone> Phones => _phones;

    #endregion

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Doctor> Create(string firstName, string middleName, string lastName)
    {
        Result<PersonalInfo> personalInfo = PersonalInfo.Create(firstName, middleName, lastName);
        if (personalInfo.IsFailure)
            return Result.Failure<Doctor>(Errors.DomainErrors.InvalidValuesError);

        return new Doctor(0, personalInfo.Value);
    }
    #endregion

    #region Add phone
    public Result AddPhone(string phone, string? name = null)
    {
        #region Create number to attach
        Result<DoctorPhone> doctorPhone = DoctorPhone.Create(phone, name);
        if (doctorPhone.IsFailure)
            return Result.Failure(Errors.DomainErrors.InvalidValuesError);
        #endregion

        #region Check duplicate
        if (Phones.Where(p => p.Phone == phone).ToList().Count > 0)
            return Result.Failure(Errors.DomainErrors.PhoneAlreadyExist);
        #endregion

        _phones.Add(doctorPhone.Value);
        return Result.Success();
    }
    #endregion

    #region Change status
    public Result ChangeStatusTo(DoctorStatus status)
    {
        if (status == DoctorStatuses.Available || status == DoctorStatuses.Busy || status == DoctorStatuses.Working)
        {
            Status = status;
            return Result.Success();
        }
        return Result.Failure(Errors.DomainErrors.InvalidValuesError);

    }
    #endregion

    #endregion
}
