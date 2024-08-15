using Domain.Primitives;

namespace Domain.Entities.People.Shared.GenderValues;

// TODO: Convert to a value object
public sealed class Gender(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #endregion
}
