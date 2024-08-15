using Domain.Primitives;

namespace Domain.Entities.People.Doctors.Shared;

// TODO: Convert phone property to a value object
public sealed class DoctorPhone(int id) : Entity(id)
{
    #region Properties

    public string? Name { get; set; }

    public string Phone { get; set; } = null!;

    #endregion
}
