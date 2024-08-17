using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Medicals.MedicalImages;

public sealed class MedicalImage : Entity
{
    #region Private ctor
    private MedicalImage(int id) : base(id) { }

    private MedicalImage(int id, string name, string? description = null) : base(id)
    {
        Name = name;
        Description = description;
    }
    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    #endregion

    #region Methods

    #region Static factory
    public static MedicalImage Create(string name, string? description = null)
    {
        if (name is null)
            throw new InvalidValuesDomainException<MedicalImage>();
        return new MedicalImage(0, name, description);
    }
    #endregion

    #endregion
}
