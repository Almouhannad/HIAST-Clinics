using Domain.Entities.Medicals.MedicalImages;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Visits.Relations.VisitMedicalImages;

// TODO: Convert result to a value object
public sealed class VisitMedicalImage : Entity
{
    #region Private ctor

    private VisitMedicalImage(int id) : base(id) { }

    private VisitMedicalImage(int id, int visitId, int medicalImageId) : base(id)
    {
        VisitId = visitId;
        MedicalImageId = medicalImageId;

        Result = null;
    }

    #endregion

    #region Properties

    #region Visit

    public int VisitId { get; private set; }
    public Visit Visit { get; private set; } = null!;

    #endregion

    #region Medical image

    public int MedicalImageId { get; private set; }
    public MedicalImage MedicalImage { get; private set; } = null!;

    #endregion

    #region Additional

    public string? Result { get; private set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<VisitMedicalImage> Create(int visitId, int medicalImageId)
    {
        if (visitId <= 0 || medicalImageId <= 0)
            return Shared.Result.Failure<VisitMedicalImage>(Errors.DomainErrors.InvalidValuesError);

        return new VisitMedicalImage(0, visitId, medicalImageId);
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
