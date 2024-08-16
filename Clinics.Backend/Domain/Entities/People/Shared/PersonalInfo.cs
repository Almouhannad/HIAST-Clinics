using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Shared;

// TODO: Convert props to value objects
public sealed class PersonalInfo : Entity
{

    #region Private ctor

    private PersonalInfo(int id) : base(id) { }

    private PersonalInfo(int id, string firstName, string middleName, string lastName) : base(id)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    #endregion

    #region Properties

    public string FirstName { get; private set; } = null!;

    public string MiddleName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string FullName
    {
        get
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }

    #endregion

    #region Methods

    #region Static factory
    public static PersonalInfo Create(string firstName, string middleName, string lastName)
    {
        if (firstName is null || middleName is null || lastName is null)
            throw new InvalidValuesDomainException<PersonalInfo>();

        return new PersonalInfo(0, firstName, middleName, lastName);
    }
    #endregion

    #endregion
}
