using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Doctors.Shared;

// TODO: Convert phone property to a value object
public sealed class DoctorPhone : Entity
{
    #region Private ctor
    private DoctorPhone(int id) : base(id) { }

    private DoctorPhone(int id, string phone, string? name = null) : base(id)
    {
        Phone = phone;
        Name = name;
    }
    #endregion

    #region Properties

    public string? Name { get; set; }

    public string Phone { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory

    public static DoctorPhone Create(string phone, string? name)
    {
        if (phone is null)
            throw new InvalidValuesDomainException<DoctorPhone>();
        return new DoctorPhone(0, phone, name);
    }

    #endregion

    #endregion
}
