using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.Shared.GenderValues;

// TODO: Convert to a value object
public sealed class Gender : Entity
{

    #region Private ctor

    private Gender(int id) : base(id) { }
    private Gender(int id, string name) : base(id)
    {
        Name = name;
    }

    #endregion

    #region Properties

    public string Name { get; private set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Result<Gender> Create(string name, int? id)
    {
        if (name is null)
            return Result.Failure<Gender>(Errors.DomainErrors.InvalidValuesError);

        if (id is not null)
        {
            if (id < 0)
                return Result.Failure<Gender>(Errors.DomainErrors.InvalidValuesError);

            return new Gender(id.Value, name);
        }

        return new Gender(0, name);
    }
    #endregion

    #endregion
}
