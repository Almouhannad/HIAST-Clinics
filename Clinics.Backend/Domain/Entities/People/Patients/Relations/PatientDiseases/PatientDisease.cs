using Domain.Entities.Medicals.Diseases;
using Domain.Primitives;
using Domain.Shared;

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

    public int PatientId { get; private set; }
    public Patient Patient { get; private set; } = null!;

    #endregion

    #region Disease

    public int DiseaseId { get; private set; }
    public Disease Disease { get; private set; } = null!;

    #endregion

    #region Additional

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<PatientDisease> Create(int patientId, int diseaseId)
    {
        if (patientId <= 0 || diseaseId <= 0)
            return Result.Failure<PatientDisease>(Errors.DomainErrors.InvalidValuesError);
        return new PatientDisease(0, patientId, diseaseId);
    }
    #endregion

    #endregion
}
