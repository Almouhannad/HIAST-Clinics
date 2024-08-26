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
            medicines.Add(new Medicine(0, Tablet, 20, "Cetamol", 500));
            medicines.Add(new Medicine(0, Tablet, 20, "Cetamol", 500));
            medicines.Add(new Medicine(0, Tablet, 10, "Paracetamol", 325));
            medicines.Add(new Medicine(0, Syrup, 100, "Cough Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Ibuprofen", 200));
            medicines.Add(new Medicine(0, Tablet, 10, "Aspirin", 100));
            medicines.Add(new Medicine(0, Syrup, 100, "Children's Cough Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Amoxicillin", 500));
            medicines.Add(new Medicine(0, Tablet, 10, "Azithromycin", 250));
            medicines.Add(new Medicine(0, Syrup, 100, "Antibiotic Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Metformin", 500));
            medicines.Add(new Medicine(0, Tablet, 10, "Atorvastatin", 20));
            medicines.Add(new Medicine(0, Syrup, 100, "Cough and Cold Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Omeprazole", 20));
            medicines.Add(new Medicine(0, Tablet, 10, "Ranitidine", 150));
            medicines.Add(new Medicine(0, Syrup, 100, "Antacid Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Levofloxacin", 500));
            medicines.Add(new Medicine(0, Tablet, 10, "Ciprofloxacin", 250));
            medicines.Add(new Medicine(0, Syrup, 100, "Antibiotic Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Doxycycline", 100));
            medicines.Add(new Medicine(0, Tablet, 10, "Tetracycline", 250));
            medicines.Add(new Medicine(0, Syrup, 100, "Antibiotic Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Prednisone", 20));
            medicines.Add(new Medicine(0, Tablet, 10, "Hydrocortisone", 10));
            medicines.Add(new Medicine(0, Syrup, 100, "Steroid Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Lisinopril", 10));
            medicines.Add(new Medicine(0, Tablet, 10, "Enalapril", 5));
            medicines.Add(new Medicine(0, Syrup, 100, "Blood Pressure Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Simvastatin", 20));
            medicines.Add(new Medicine(0, Tablet, 10, "Atorvastatin", 10));
            medicines.Add(new Medicine(0, Syrup, 100, "Cholesterol Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Albuterol", 2));
            medicines.Add(new Medicine(0, Tablet, 10, "Ipratropium", 2));
            medicines.Add(new Medicine(0, Syrup, 100, "Asthma Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Rabeprazole", 20));
            medicines.Add(new Medicine(0, Tablet, 10, "Omeprazole", 20));
            medicines.Add(new Medicine(0, Syrup, 100, "Antacid Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Citalopram", 20));
            medicines.Add(new Medicine(0, Tablet, 10, "Fluoxetine", 20));
            medicines.Add(new Medicine(0, Syrup, 100, "Antidepressant Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Amlodipine", 5));
            medicines.Add(new Medicine(0, Tablet, 10, "Lisinopril", 10));
            medicines.Add(new Medicine(0, Syrup, 100, "Blood Pressure Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Metoprolol", 50));
            medicines.Add(new Medicine(0, Tablet, 10, "Propranolol", 20));
            medicines.Add(new Medicine(0, Syrup, 100, "Heart Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Warfarin", 5));
            medicines.Add(new Medicine(0, Tablet, 10, "Aspirin", 100));
            medicines.Add(new Medicine(0, Syrup, 100, "Blood Thinner Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Furosemide", 40));
            medicines.Add(new Medicine(0, Tablet, 10, "Hydrochlorothiazide", 25));
            medicines.Add(new Medicine(0, Syrup, 100, "Diuretic Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Spironolactone", 25));
            medicines.Add(new Medicine(0, Tablet, 10, "Triamterene", 50));
            medicines.Add(new Medicine(0, Syrup, 100, "Diuretic Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Allopurinol", 100));
            medicines.Add(new Medicine(0, Tablet, 10, "Colchicine", 6));
            medicines.Add(new Medicine(0, Syrup, 100, "Gout Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Glipizide", 5));
            medicines.Add(new Medicine(0, Tablet, 10, "Metformin", 500));
            medicines.Add(new Medicine(0, Syrup, 100, "Diabetes Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Lorazepam", 1));
            medicines.Add(new Medicine(0, Tablet, 10, "Alprazolam", 5));
            medicines.Add(new Medicine(0, Syrup, 100, "Anxiety Syrup", 50));
            medicines.Add(new Medicine(0, Tablet, 20, "Zolpidem", 5));
            medicines.Add(new Medicine(0, Tablet, 10, "Eszopiclone", 2));
            medicines.Add(new Medicine(0, Syrup, 100, "Sleep Syrup", 50));

            foreach (var medicine in medicines)
            {
                _clinicsContext.Entry(medicine.MedicineForm).State = EntityState.Unchanged;
                _clinicsContext.Set<Medicine>().Add(medicine);
            }
            await _clinicsContext.SaveChangesAsync();

        }

    }
}