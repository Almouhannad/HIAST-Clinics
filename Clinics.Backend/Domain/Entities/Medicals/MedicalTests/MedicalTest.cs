using Domain.Primitives;
using Domain.Shared;

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

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    #endregion

    #region Methods

    #region Static factory
    public static Result<MedicalTest> Create(string name, string description)
    {
        if (name is null)
            return Result.Failure<MedicalTest>(Errors.DomainErrors.InvalidValuesError);
        return new MedicalTest(0, name, description);
    }
    #endregion

    #endregion
}
