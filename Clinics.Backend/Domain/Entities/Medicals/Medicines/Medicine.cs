using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Medicals.Medicines;

// TODO: Convert Dosage to value object
public sealed class Medicine : Entity
{
    #region Private ctor

    private Medicine(int id) : base(id) { }

    private Medicine(int id, MedicineForm medicineForm, int amount, string name, decimal dosage) : base(id)
    {
        MedicineForm = medicineForm;
        Amount = amount;
        Name = name;
        Dosage = dosage;
    }

    #endregion

    #region Properties

    public MedicineForm MedicineForm { get; set; } = null!;

    public int Amount { get; set; }

    public string Name { get; set; } = null!;

    public decimal Dosage { get; set; }

    #region Navigations

    #region Patients
    private readonly List<PatientMedicine> _patients = [];
    public IReadOnlyCollection<PatientMedicine> Patients => _patients;

    #endregion


    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Medicine Create(string form, int amount, string name, decimal dosage)
    {
        if (form is null || name is null || amount < 0 || dosage < 0)
            throw new InvalidValuesDomainException<Medicine>();

        #region Check form
        MedicineForm selectedMedicineForm;

        MedicineForm tablet = MedicineForms.Tablet;
        MedicineForm syrup = MedicineForms.Syrup;

        if (form == tablet.Name)
            selectedMedicineForm = tablet;
        else if (form == syrup.Name)
            selectedMedicineForm = syrup;
        else throw new InvalidValuesDomainException<MedicineForm>();

        #endregion

        return new Medicine(0, selectedMedicineForm, amount, name, dosage);
    }
    #endregion

    #endregion

}
