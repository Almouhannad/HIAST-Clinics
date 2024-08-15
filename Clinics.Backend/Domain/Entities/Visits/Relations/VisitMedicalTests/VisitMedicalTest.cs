using Domain.Entities.Medicals.MedicalTests;
using Domain.Primitives;

namespace Domain.Entities.Visits.Relations.VisitMedicalTests;

// TODO: Convert result to a value object
public sealed class VisitMedicalTest(int id) : Entity(id)
{
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
}
