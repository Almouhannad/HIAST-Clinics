using Domain.Primitives;

namespace Domain.Entities.People.Patients.Relations.PatientMedicines;

public sealed class PatientMedicine(int id) : Entity(id)
{
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
}
