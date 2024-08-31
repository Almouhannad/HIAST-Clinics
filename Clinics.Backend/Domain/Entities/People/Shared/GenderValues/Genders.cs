using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Shared.GenderValues;

public static class Genders
{
    #region Constant values

    public static int Count => 2;

    private readonly static Gender _male = Gender.Create("ذكر", 1).Value;
    public static Gender Male => _male;

    private readonly static Gender _female = Gender.Create("أنثى", 2).Value;
    public static Gender Female => _female;

    #endregion
}
