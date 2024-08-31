using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Doctors.Shared.DoctorStatusValues;

public static class DoctorStatuses
{
    #region Constant values

    public static int Count => 3;

    private readonly static DoctorStatus _available = DoctorStatus.Create("متاح", 1).Value;
    public static DoctorStatus Available => _available;

    private readonly static DoctorStatus _working = DoctorStatus.Create("لديه مريض", 2).Value;
    public static DoctorStatus Working => _working;

    private readonly static DoctorStatus _busy = DoctorStatus.Create("مشغول", 3).Value;
    public static DoctorStatus Busy => _busy;

    #endregion
}
