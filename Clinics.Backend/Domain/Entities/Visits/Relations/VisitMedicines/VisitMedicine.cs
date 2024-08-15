using Domain.Entities.Medicals.Medicines;
using Domain.Primitives;

namespace Domain.Entities.Visits.Relations.VisitMedicines;

public sealed class VisitMedicine(int id) : Entity(id)
{
    #region Properties

    #region Visit

    public int VisitId { get; set; }
    public Visit Visit { get; set; } = null!;

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
