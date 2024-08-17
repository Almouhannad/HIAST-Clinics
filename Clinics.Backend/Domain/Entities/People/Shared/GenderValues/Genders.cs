namespace Domain.Entities.People.Shared.GenderValues;

public static class Genders
{
    #region Constant id values 

    public static Gender Male => Gender.Create("ذكر", 1);

    public static Gender Female => Gender.Create("أنثى", 2);

    #endregion
}
