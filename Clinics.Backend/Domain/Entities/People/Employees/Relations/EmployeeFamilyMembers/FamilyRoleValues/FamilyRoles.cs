namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;

public static class FamilyRoles
{
    #region Constant id values

    public static FamilyRole Husband => FamilyRole.Create("زوج", 1);

    public static FamilyRole Wife => FamilyRole.Create("زوجة", 2);

    public static FamilyRole Son => FamilyRole.Create("ابن", 3);

    public static FamilyRole Daughter => FamilyRole.Create("ابنة", 4);

    #endregion
}
