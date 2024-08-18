using Domain.Entities.Medicals.Medicines;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.People.Patients.Relations.PatientMedicines;

public sealed class PatientMedicine : Entity
{


    #region Private ctor
    private PatientMedicine(int id) : base(id)
    {
    }
    private PatientMedicine(int id, int patientId, int medicineId, int number) : base(id)
    {
        PatientId = patientId;
        MedicineId = medicineId;
        Number = number;
    }

    #endregion

    #region Properties

    #region Patient

    public int PatientId { get; private set; }
    public Patient Patient { get; private set; } = null!;

    #endregion

    #region Medicine

    public int MedicineId { get; private set; }
    public Medicine Medicine { get; private set; } = null!;

    #endregion

    #region Additional

    public int Number { get; private set; }

    #endregion


    #endregion

    #region Methods

    #region Static factory
    public static Result<PatientMedicine> Create(int patientId, int medicineId, int number)
    {
        if (patientId <= 0 || medicineId <= 0 || number <= 0)
            return Result.Failure<PatientMedicine>(Errors.DomainErrors.InvalidValuesError);
        return new PatientMedicine(0, patientId, medicineId, number);
    }
    #endregion

    #endregion
}
