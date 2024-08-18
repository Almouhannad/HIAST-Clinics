using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;

public static class FamilyRoles
{
    #region Constant id values

    public static int Count => 4;
    public static FamilyRole Husband
    {
        get
        {
            var result = FamilyRole.Create("زوج", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<FamilyRole>();
            return result.Value;
        }
    }

    public static FamilyRole Wife
    {
        get
        {
            var result = FamilyRole.Create("زوجة", 2);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<FamilyRole>();
            return result.Value;
        }
    }

    public static FamilyRole Son
    {
        get
        {
            var result = FamilyRole.Create("ابن", 3);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<FamilyRole>();
            return result.Value;
        }
    }

    public static FamilyRole Daughter
    {
        get
        {
            var result = FamilyRole.Create("ابنة", 4);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<FamilyRole>();
            return result.Value;
        }
    }

    #endregion
}
