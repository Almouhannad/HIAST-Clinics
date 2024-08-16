using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Medicals.Hospitals;

public sealed class Hospital : Entity
{
    #region Private ctor

    private Hospital(int id) : base(id) { }

    private Hospital(int id, string name) : base(id)
    {
        Name = name;
    }

    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Hospital Create(string name)
    {
        if (name is null)
            throw new InvalidValuesDomainException<Hospital>();
        return new Hospital(0, name);
    }
    #endregion

    #endregion
}
