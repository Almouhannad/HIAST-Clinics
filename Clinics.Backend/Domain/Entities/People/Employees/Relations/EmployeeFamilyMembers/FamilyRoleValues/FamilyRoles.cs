using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;

public static class FamilyRoles
{
    #region Constant id values

    public static int Count => 4;

    public readonly static FamilyRole _husband = FamilyRole.Create("زوج", 1).Value;
    public static FamilyRole Husband => _husband;

    public readonly static FamilyRole _wife = FamilyRole.Create("زوجة", 2).Value;
    public static FamilyRole Wife => _wife;

    public readonly static FamilyRole _son = FamilyRole.Create("ابن", 3).Value;
    public static FamilyRole Son => _son;

    public readonly static FamilyRole _daughter = FamilyRole.Create("ابنة", 4).Value;
    public static FamilyRole Daughter => _daughter;
    

    #endregion
}
