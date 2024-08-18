using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase.FamilyRoles;

public class SeedFamilyRoles : ISeed<FamilyRole>
{
    #region Ctor DI
    private readonly ClinicsDbContext _clinicsContext;

    public SeedFamilyRoles(ClinicsDbContext clinicsContext)
    {
        _clinicsContext = clinicsContext;
    }
    #endregion

    public async Task Seed()
    {
        DbSet<FamilyRole> familyRoles = _clinicsContext.Set<FamilyRole>();
        if (familyRoles.ToList().Count !=
            Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRoles.Count)
        {
            familyRoles.RemoveRange(familyRoles.ToList());

            familyRoles.Add
                (Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRoles.Husband);

            familyRoles.Add
                (Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRoles.Wife);

            familyRoles.Add
                (Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRoles.Son);

            familyRoles.Add
                (Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues.FamilyRoles.Daughter);

            await _clinicsContext.SaveChangesAsync();
        }
    }
}
