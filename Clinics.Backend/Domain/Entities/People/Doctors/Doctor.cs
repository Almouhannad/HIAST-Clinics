using Domain.Entities.People.Doctors.Shared;
using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Entities.People.Shared;
using Domain.Primitives;

namespace Domain.Entities.People.Doctors;

public sealed class Doctor(int id) : Entity(id)
{
    #region Properties

    public PersonalInfo PersonalInfo { get; set; } = null!;

    public DoctorStatus Status { get; set; } = null!;

    #region Navigations

    public ICollection<DoctorPhone> Phones { get; set; } = [];

    #endregion

    #endregion
}
