using Domain.Entities.Medicals.Medicines;
using MedicinesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace API.SeedDatabaseHelper;

public class SeedMedicinesHelper
{
    public static async Task Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var medicinesAPIServices = serviceScope.ServiceProvider.GetService<IMedicinesAPIServices>();
            var context = serviceScope.ServiceProvider.GetService<ClinicsDbContext>();

            if (medicinesAPIServices is not null && context is not null)
            {
                var Medicines = context.Set<Medicine>();
                var currentCount = (await Medicines.ToListAsync()).Count;
                if (currentCount == 0)
                {
                    var medicinesResult = await medicinesAPIServices.GetAll();
                    if (medicinesResult.IsSuccess)
                    {
                        var medicines = medicinesResult.Value;
                        foreach (var medicine in medicines)
                        {
                            context.Entry(medicine.MedicineForm).State = EntityState.Unchanged;
                            Medicines.Add(medicine);
                        }
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error seeding medicines: {medicinesResult.Error}");
                    }
                }
            }
        }
    }
}