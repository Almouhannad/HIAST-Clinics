using Domain.Primitives;
using Domain.Shared;

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

    public string Name { get; private set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Result<DoctorStatus> Create(string name, int? id)
    {
        if (name is null)
            return Result.Failure<DoctorStatus>(Errors.DomainErrors.InvalidValuesError);
        if (id is not null)
        {
            if (id < 0)
                return Result.Failure<DoctorStatus>(Errors.DomainErrors.InvalidValuesError);

            return new DoctorStatus(id.Value, name);
        }

        return new DoctorStatus(0, name);
    }
    #endregion

    #endregion
}
