using Domain.Primitives;
using Domain.Shared;

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
    public static Result<Hospital> Create(string name)
    {
        if (name is null)
            return Result.Failure<Hospital>(Errors.DomainErrors.InvalidValuesError);
        return new Hospital(0, name);
    }
    #endregion

    #endregion
}
