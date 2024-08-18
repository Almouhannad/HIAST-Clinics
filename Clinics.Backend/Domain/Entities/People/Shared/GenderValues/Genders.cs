using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Shared.GenderValues;

public static class Genders
{
    #region Constant values

    public static int Count => 2;

    public static Gender Male
    {
        get
        {
            var result = Gender.Create("ذكر", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<Gender>();
            return result.Value;
        }
    }

    public static Gender Female
    {
        get
        {
            var result = Gender.Create("أنثى", 2);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<Gender>();
            return result.Value;
        }
    }

    #endregion
}
