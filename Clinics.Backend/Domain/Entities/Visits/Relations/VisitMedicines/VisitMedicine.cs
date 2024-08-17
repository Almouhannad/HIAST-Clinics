using Domain.Entities.Medicals.Medicines;
using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

namespace Domain.Entities.Visits.Relations.VisitMedicines;

public sealed class VisitMedicine : Entity
{

    #region Private ctor
    private VisitMedicine(int id) : base(id) { }

    private VisitMedicine(int id, int visitId, int medicineId, int number) : base(id)
    {
        VisitId = visitId;
        MedicineId = medicineId;

        Number = number;
    }
    #endregion

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

    #region Methods

    #region Static factory
    public static VisitMedicine Create(int visitId, int medicineId, int number)
    {
        if (visitId <= 0 || medicineId <= 0 || number <= 0)
            throw new InvalidValuesDomainException<VisitMedicine>();

        return new VisitMedicine(0, visitId, medicineId, number);
    }
    #endregion

    #endregion
}
