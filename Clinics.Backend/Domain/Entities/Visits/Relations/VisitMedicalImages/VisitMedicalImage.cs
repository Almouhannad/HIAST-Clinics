using Domain.Entities.Medicals.MedicalImages;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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

    public int VisitId { get; set; }
    public Visit Visit { get; set; } = null!;

    #endregion

    #region Medical image

    public int MedicalImageId { get; set; }
    public MedicalImage MedicalImage { get; set; } = null!;

    #endregion

    #region Additional

    public string? Result { get; set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static VisitMedicalImage Create(int visitId, int medicalImageId)
    {
        if (visitId <= 0 || medicalImageId <= 0)
            throw new InvalidValuesDomainException<VisitMedicalImage>();

        return new VisitMedicalImage(0, visitId, medicalImageId);
    }
    #endregion

    #region Add result
    public void AddResult(string result)
    {
        if (result is null)
            throw new InvalidValuesDomainException<VisitMedicalImage>();

        Result = result;
    }
    #endregion

    #endregion
}
