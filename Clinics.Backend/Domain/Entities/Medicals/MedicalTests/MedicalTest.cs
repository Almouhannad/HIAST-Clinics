using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Medicals.MedicalTests;

public sealed class MedicalTest : Entity
{
    #region Private ctor
    private MedicalTest(int id) : base(id) { }

    private MedicalTest(int id, string name, string? description = null) : base(id)
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
    public static MedicalTest Create(string name, string description)
    {
        if (name is null)
            throw new InvalidValuesDomainException<MedicalTest>();
        return new MedicalTest(0, name, description);
    }
    #endregion

    #endregion
}
