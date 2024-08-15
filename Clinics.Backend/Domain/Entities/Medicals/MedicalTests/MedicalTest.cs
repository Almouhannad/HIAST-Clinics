using Domain.Primitives;

namespace Domain.Entities.Medicals.MedicalTests;

public sealed class MedicalTest(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    #endregion
}
