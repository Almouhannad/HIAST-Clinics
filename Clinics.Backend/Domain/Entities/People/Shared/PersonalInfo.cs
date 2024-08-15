using Domain.Primitives;

namespace Domain.Entities.People.Shared;

// TODO: Convert props to value objects
public sealed class PersonalInfo(int id) : Entity(id)
{

    #region Properties

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    #endregion

}
