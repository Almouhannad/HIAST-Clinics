using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;

public static class DoctorStatuses
{
    #region Constant values

    public static DoctorStatus Available
    {
        get
        {
            var result = DoctorStatus.Create("متاح", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<DoctorStatus>();
            return result.Value;
        }
    }

    public static DoctorStatus Working
    {
        get
        {
            var result = DoctorStatus.Create("لديه مريض", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<DoctorStatus>();
            return result.Value;
        }
    }

    public static DoctorStatus Busy
    {
        get
        {
            var result = DoctorStatus.Create("مشغول", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<DoctorStatus>();
            return result.Value;
        }
    }

    #endregion
}
