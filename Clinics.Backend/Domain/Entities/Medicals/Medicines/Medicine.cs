using Domain.Entities.Medicals.Medicines.MedicineFormValues;
using Domain.Entities.People.Patients.Relations.PatientMedicines;
using Domain.Primitives;
using Domain.Shared;

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

    public MedicineForm MedicineForm { get; private set; } = null!;

    public int Amount { get; private set; }

    public string Name { get; private set; } = null!;

    public decimal Dosage { get; private set; }

    #region Navigations

    #region Patients
    private readonly List<PatientMedicine> _patients = [];
    public IReadOnlyCollection<PatientMedicine> Patients => _patients;

    #endregion


    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<Medicine> Create(string form, int amount, string name, decimal dosage)
    {
        if (form is null || name is null || amount < 0 || dosage < 0)
            return Result.Failure<Medicine>(Errors.DomainErrors.InvalidValuesError);

        #region Check form
        Result<MedicineForm> selectedMedicineForm = new(null, false, Errors.DomainErrors.InvalidValuesError);

        MedicineForm tablet = MedicineForms.Tablet;
        MedicineForm syrup = MedicineForms.Syrup;

        if (form == tablet.Name)
            selectedMedicineForm = Result.Success<MedicineForm>(tablet);
        else if (form == syrup.Name)
            selectedMedicineForm = Result.Success<MedicineForm>(syrup);

        if (selectedMedicineForm.IsFailure)
            return Result.Failure<Medicine>(selectedMedicineForm.Error);
        #endregion

        return new Medicine(0, selectedMedicineForm.Value, amount, name, dosage);
    }
    #endregion

    #endregion

}
