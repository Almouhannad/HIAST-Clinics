using Domain.Entities.Medicals.Diseases;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.People.Patients.Relations.PatientDiseases;

public sealed class PatientDisease : Entity
{
    #region Private ctor
    private PatientDisease(int id) : base(id)
    {
    }

    private PatientDisease(int id, int patientId, int diseaseId) : base(id)
    {
        PatientId = patientId;
        DiseaseId = diseaseId;
    }
    #endregion

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

    #region Methods

    #region Static factory
    public static PatientDisease Create(int patientId, int diseaseId)
    {
        if (patientId <= 0 || diseaseId <= 0)
            throw new InvalidValuesDomainException<PatientDisease>();
        return new PatientDisease(0, patientId, diseaseId);
    }
    #endregion

    #endregion
}
