using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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
    public static Gender Create(string name, int? id)
    {
        if (name is null)
            throw new InvalidValuesDomainException<Gender>();

        if (id < 0)
            throw new InvalidValuesDomainException<Gender>();

        if (id is not null)
            return new Gender(id.Value, name);

        return new Gender(0, name);
    }
    #endregion

    #endregion
}
