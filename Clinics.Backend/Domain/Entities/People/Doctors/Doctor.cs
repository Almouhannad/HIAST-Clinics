using Domain.Entities.People.Doctors.Shared;
using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Entities.People.Shared;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    public PersonalInfo PersonalInfo { get; set; } = null!;

    public DoctorStatus Status { get; set; } = null!;

    #region Navigations

    public ICollection<DoctorPhone> Phones { get; set; } = [];

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Doctor Create(string firstName, string middleName, string lastName)
    {
        PersonalInfo personalInfo;
        try
        {
            personalInfo = PersonalInfo.Create(firstName, middleName, lastName);
        }
        catch
        {
            throw;
        }

        return new Doctor(0, personalInfo);
    }
    #endregion

    #region Add phone
    public void AddPhone(string phone, string? number = null)
    {
        DoctorPhone doctorPhone;
        try
        {
            doctorPhone = DoctorPhone.Create(phone, number);
        }
        catch
        {
            throw;
        }

        if (Phones is null)
            Phones = [];

        Phones.Add(doctorPhone);
    }
    #endregion

    #region Change status
    public void ChangeStatusTo(DoctorStatus status)
    {
        if (status == DoctorStatuses.Available || status == DoctorStatuses.Busy || status == DoctorStatuses.Working)
            Status = status;
        throw new InvalidValuesDomainException<DoctorStatus>();
    }
    #endregion

    #endregion
}
