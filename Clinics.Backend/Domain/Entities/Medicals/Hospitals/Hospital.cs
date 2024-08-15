using Domain.Primitives;

namespace Domain.Entities.Medicals.Hospitals;

public sealed class Hospital(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #endregion
}
