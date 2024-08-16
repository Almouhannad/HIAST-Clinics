namespace Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;

public static class DoctorStatuses
{
    #region Constant id values

    public static DoctorStatus Available => DoctorStatus.Create("متاح", 1);

    public static DoctorStatus Working => DoctorStatus.Create("لديه مريض", 1);

    public static DoctorStatus Busy => DoctorStatus.Create("مشغول", 1);

    #endregion
}
