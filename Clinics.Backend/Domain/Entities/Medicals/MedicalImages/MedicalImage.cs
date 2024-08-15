using Domain.Primitives;

namespace Domain.Entities.Medicals.MedicalImages;

public sealed class MedicalImage(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    #endregion
}
