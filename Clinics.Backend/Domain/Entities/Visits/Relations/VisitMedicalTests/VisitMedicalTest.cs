using Domain.Entities.Medicals.MedicalTests;
using Domain.Entities.Visits.Relations.VisitMedicalImages;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Visits.Relations.VisitMedicalTests;

// TODO: Convert result to a value object
public sealed class VisitMedicalTest : Entity
{
    #region Private ctor

    private VisitMedicalTest(int id) : base(id) { }

    private VisitMedicalTest(int id, int visitId, int medicalTestId) : base(id)
    {
        VisitId = visitId;
        MedicalTestId = medicalTestId;

        Result = null;
    }

    #endregion

    #region Properties

    #region Visit

    public int VisitId { get; set; }
    public Visit Visit { get; set; } = null!;

    #endregion

    #region Medical test

    public int MedicalTestId { get; set; }
    public MedicalTest MedicalTest { get; set; } = null!;

    #endregion

    #region Additional

    public string? Result { get; set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static VisitMedicalTest Create(int visitId, int medicalTestId)
    {
        if (visitId <= 0 || medicalTestId <= 0)
            throw new InvalidValuesDomainException<VisitMedicalTest>();

        return new VisitMedicalTest(0, visitId, medicalTestId);
    }
    #endregion

    #region Add result
    public void AddResult(string result)
    {
        if (result is null)
            throw new InvalidValuesDomainException<VisitMedicalTest>();

        Result = result;
    }
    #endregion

    #endregion
}
