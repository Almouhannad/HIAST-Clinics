using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;

public sealed class DoctorStatus : Entity
{
    #region Private ctor
    private DoctorStatus(int id) : base(id)
    {

    }

    private DoctorStatus(int id, string name) : base(id)
    {
        Name = name;
    }
    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static DoctorStatus Create(string name, int? id)
    {
        if (name is null)
            throw new InvalidValuesDomainException<DoctorStatus>();
        if (id is not null)
        {
            if (id < 0)
                throw new InvalidValuesDomainException<DoctorStatus>();
            return new DoctorStatus(id.Value, name);
        }

        return new DoctorStatus(0, name);
    }
    #endregion

    #endregion
}
