using Domain.Entities.Medicals.MedicalImages;
using Domain.Primitives;

namespace Domain.Entities.Visits.Relations.VisitMedicalImages;

// TODO: Convert result to a value object
public sealed class VisitMedicalImage(int id) : Entity(id)
{
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
}
