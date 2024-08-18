using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase.MedicineForms;

public class SeedMedicineForms : ISeed<MedicineForm>
{
    #region Ctor DI
    private readonly ClinicsDbContext _clinicsContext;

    public SeedMedicineForms(ClinicsDbContext clinicsContext)
    {
        _clinicsContext = clinicsContext;
    }
    #endregion
    public async Task Seed()
    {
        DbSet<MedicineForm> medicineForms = _clinicsContext.Set<MedicineForm>();
        if (medicineForms.ToList().Count !=
            Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForms.Count)
        {
            medicineForms.RemoveRange(medicineForms.ToList());

            medicineForms
                .Add(Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForms.Tablet);

            medicineForms
                .Add(Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForms.Syrup);

            await _clinicsContext.SaveChangesAsync();
        }
    }
}
