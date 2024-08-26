using Persistence.SeedDatabase.AdminUser;
using Persistence.SeedDatabase.Medicines;

namespace API.SeedDatabaseHelper;

public class SeedMedicinesHelper
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var seedMedicines = serviceScope.ServiceProvider.GetRequiredService<ISeedMedicines>();
            await seedMedicines.Seed();
        }
    }
}
