using Domain.Primitives;

namespace Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;

public sealed class DoctorStatus(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #endregion
}
