using Domain.Entities.Medicals.MedicalTests;
using Domain.Primitives;
using Domain.Shared;

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

    public int VisitId { get; private set; }
    public Visit Visit { get; private set; } = null!;

    #endregion

    #region Medical test

    public int MedicalTestId { get; private set; }
    public MedicalTest MedicalTest { get; private set; } = null!;

    #endregion

    #region Additional

    public string? Result { get; private set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<VisitMedicalTest> Create(int visitId, int medicalTestId)
    {
        if (visitId <= 0 || medicalTestId <= 0)
            return Shared.Result.Failure<VisitMedicalTest>(Errors.DomainErrors.InvalidValuesError);

        return new VisitMedicalTest(0, visitId, medicalTestId);
    }
    #endregion

    #region Add result
    public Result AddResult(string result)
    {
        if (result is null)
            return Shared.Result.Failure(Errors.DomainErrors.InvalidValuesError);

        Result = result;
        return Shared.Result.Success();
    }
    #endregion

    #endregion
}
