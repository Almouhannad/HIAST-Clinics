using Domain.Entities.Medicals.Medicines;
using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.SeedDatabase.Medicines;

public class SeedMedicines : ISeedMedicines
{
    #region Ctor DI
    private readonly ClinicsDbContext _clinicsContext;

    public SeedMedicines(ClinicsDbContext clinicsContext)
    {
        _clinicsContext = clinicsContext;
    }
    #endregion

    private readonly MedicineForm Tablet = Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForms.Tablet;
    private readonly MedicineForm Syrup = Domain.Entities.Medicals.Medicines.MedicineFormValues.MedicineForms.Syrup;

    public async Task Seed()
    {
        var currentSize = (await (_clinicsContext.Set<Medicine>().ToListAsync())).Count;
        if (currentSize == 0)
        {
            List<Medicine> medicines = new();
            medicines.Add(new Medicine(0, Tablet, 10, "Paracetamol", 325));
            medicines.Add(new Medicine(0, Tablet, 10, "Cetamol", 325));
            medicines.Add(new Medicine(0, Tablet, 10, "Ceatcodaen", 325));
            medicines.Add(new Medicine(0, Tablet, 10, "Cetaprofin", 325));
            medicines.Add(new Medicine(0, Tablet, 10, "Cetacold", 325));
            medicines.Add(new Medicine(0, Tablet, 10, "Cetagrape", 325));
            medicines.Add(new Medicine(0, Syrup, 100, "Cough", 50));
            medicines.Add(new Medicine(0, Tablet, 12, "Aspirin", 500));
            medicines.Add(new Medicine(0, Syrup, 120, "Pediatric", 60));
            medicines.Add(new Medicine(0, Tablet, 8, "Amoxicillin", 250));
            medicines.Add(new Medicine(0, Syrup, 150, "Acetaminophen", 160));
            medicines.Add(new Medicine(0, Tablet, 15, "Ibuprofen", 400));
            medicines.Add(new Medicine(0, Tablet, 20, "Loratadine", 10));
            medicines.Add(new Medicine(0, Syrup, 200, "Vitamin D", 400));
            medicines.Add(new Medicine(0, Tablet, 30, "Nurofen", 200));
            medicines.Add(new Medicine(0, Syrup, 120, "Antihistamine", 5));
            medicines.Add(new Medicine(0, Tablet, 14, "Claritin", 10));
            medicines.Add(new Medicine(0, Syrup, 150, "Flu", 100));
            medicines.Add(new Medicine(0, Tablet, 10, "Panadol", 500));
            medicines.Add(new Medicine(0, Syrup, 100, "Ibuprofen", 100));
            medicines.Add(new Medicine(0, Tablet, 16, "Spirin", 100));
            medicines.Add(new Medicine(0, Syrup, 180, "Cough Suppressant", 60));
            medicines.Add(new Medicine(0, Tablet, 18, "Cetal", 500));
            medicines.Add(new Medicine(0, Syrup, 120, "Tuskan", 120));
            medicines.Add(new Medicine(0, Tablet, 12, "Naproxen", 250));
            medicines.Add(new Medicine(0, Syrup, 100, "Bronchicum", 150));
            medicines.Add(new Medicine(0, Tablet, 14, "Fenistil", 5));
            medicines.Add(new Medicine(0, Syrup, 100, "Fenistil", 30));
            medicines.Add(new Medicine(0, Tablet, 10, "Diclofenac", 50));
            medicines.Add(new Medicine(0, Syrup, 125, "Amoclan", 250));
            medicines.Add(new Medicine(0, Tablet, 12, "Zinnat", 250));
            medicines.Add(new Medicine(0, Syrup, 200, "Novalgin", 500));
            medicines.Add(new Medicine(0, Tablet, 15, "Milga", 250));
            medicines.Add(new Medicine(0, Syrup, 150, "Multivitamin", 50));
            medicines.Add(new Medicine(0, Tablet, 18, "Trifluor", 250));
            medicines.Add(new Medicine(0, Syrup, 100, "Zithromax", 200));
            medicines.Add(new Medicine(0, Tablet, 10, "Ferrotron", 50));
            medicines.Add(new Medicine(0, Syrup, 100, "Feroglobin", 100));
            medicines.Add(new Medicine(0, Tablet, 16, "Farcolin", 200));
            medicines.Add(new Medicine(0, Syrup, 120, "Clindamycin", 300));
            medicines.Add(new Medicine(0, Tablet, 12, "Trimed Flu", 325));
            medicines.Add(new Medicine(0, Syrup, 150, "Prospan", 100));
            medicines.Add(new Medicine(0, Tablet, 20, "Omeprazole", 40));
            medicines.Add(new Medicine(0, Syrup, 200, "Lactulose", 15));
            medicines.Add(new Medicine(0, Tablet, 18, "Tavanic", 500));
            medicines.Add(new Medicine(0, Syrup, 100, "Ventolin", 2));
            medicines.Add(new Medicine(0, Tablet, 10, "Losartan", 50));
            medicines.Add(new Medicine(0, Syrup, 120, "Promax", 100));
            medicines.Add(new Medicine(0, Tablet, 12, "Nurofen Cold & Flu", 200));
            medicines.Add(new Medicine(0, Syrup, 150, "Guava", 60));
            medicines.Add(new Medicine(0, Tablet, 8, "Profenid", 150));
            medicines.Add(new Medicine(0, Syrup, 100, "Depakine", 200));


            foreach (var medicine in medicines)
            {
                _clinicsContext.Entry(medicine.MedicineForm).State = EntityState.Unchanged;
                _clinicsContext.Set<Medicine>().Add(medicine);
            }
            await _clinicsContext.SaveChangesAsync();

        }

    }
}