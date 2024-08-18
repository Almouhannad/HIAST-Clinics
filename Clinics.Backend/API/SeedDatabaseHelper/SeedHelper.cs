using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Domain.Entities.People.Doctors.Shared.Constants.DoctorStatusValues;
using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers.FamilyRoleValues;
using Domain.Entities.People.Shared.GenderValues;
using Persistence.SeedDatabase;

namespace API.SeedDatabaseHelper;

public class SeedHelper
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var seedGenders = serviceScope.ServiceProvider.GetRequiredService<ISeed<Gender>>();
            await seedGenders.Seed();

            var seedDoctorStatuses = serviceScope.ServiceProvider.GetRequiredService<ISeed<DoctorStatus>>();
            await seedDoctorStatuses.Seed();

            var seedFamilyRoles = serviceScope.ServiceProvider.GetRequiredService<ISeed<FamilyRole>>();
            await seedFamilyRoles.Seed();

            var seedMedicineForms = serviceScope.ServiceProvider.GetRequiredService<ISeed<MedicineForm>>();
            await seedMedicineForms.Seed();
        }
    }
}
