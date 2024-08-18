using Domain.Primitives;
using Domain.Shared;

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

    public string? Name { get; private set; }

    public string Phone { get; private set; } = null!;

    #endregion

    #region Methods

    #region Static factory

    public static Result<DoctorPhone> Create(string phone, string? name)
    {
        if (phone is null)
            return Result.Failure<DoctorPhone>(Errors.DomainErrors.InvalidValuesError);
        return new DoctorPhone(0, phone, name);
    }

    #endregion

    #endregion
}
