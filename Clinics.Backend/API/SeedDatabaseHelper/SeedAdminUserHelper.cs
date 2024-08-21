using Domain.Entities.Identity.UserRoles;
using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.Shared.GenderValues;
using Persistence.SeedDatabase;
using Persistence.SeedDatabase.AdminUser;

namespace API.SeedDatabaseHelper;

public class SeedAdminUserHelper
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var seedAdminUser = serviceScope.ServiceProvider.GetRequiredService<ISeedAdminUser>();
            await seedAdminUser.Seed();
        }
    }
}
