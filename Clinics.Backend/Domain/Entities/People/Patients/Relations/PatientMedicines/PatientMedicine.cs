using Domain.Entities.Medicals.Medicines;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    #endregion

    #region Medicine

    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;

    #endregion

    #region Additional

    public int Number { get; set; }

    #endregion


    #endregion

    #region Methods

    #region Static factory
    public static PatientMedicine Create(int patientId, int medicineId, int number)
    {
        if (patientId <= 0 || medicineId <= 0 || number <= 0)
            throw new InvalidValuesDomainException<PatientMedicine>();
        return new PatientMedicine(0, patientId, medicineId, number);
    }
    #endregion

    #endregion
}
