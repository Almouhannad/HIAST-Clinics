using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Domain.Primitives;

namespace Domain.Entities.Medicals.Medicines;

// TODO: Convert Dosage to value object
public sealed class Medicine(int id) : Entity(id)
{
    #region Properties

    public MedicineForm MedicineForm { get; set; } = null!;

    public int Amount { get; set; }

    public string Name { get; set; } = null!;

    public decimal Dosage { get; set; }

    #region Navigations

    public ICollection<PatientMedicine> Patients { get; set; } = [];

    #endregion

    #endregion
}
