using Domain.Primitives;

namespace Domain.Entities.People.Patients.Relations.PatientDiseases;

public sealed class PatientDisease(int id) : Entity(id)
{

    #region Properties

    #region Patient

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    #endregion

    #region Disease

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; } = null!;

    #endregion

    #region Additional

    #endregion

    #endregion
}
