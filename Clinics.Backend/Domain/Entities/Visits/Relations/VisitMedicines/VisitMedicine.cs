using Domain.Entities.Medicals.Medicines;
using Domain.Primitives;
using Domain.Shared;

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

    public int VisitId { get; private set; }
    public Visit Visit { get; private set; } = null!;

    #endregion

    #region Medicine

    public int MedicineId { get; private set; }
    public Medicine Medicine { get; private set; } = null!;

    #endregion

    #region Additional

    public int Number { get; private set; }

    #endregion

    #endregion

    #region Methods

    #region Static factory
    public static Result<VisitMedicine> Create(int visitId, int medicineId, int number)
    {
        if (visitId <= 0 || medicineId <= 0 || number <= 0)
            return Result.Failure<VisitMedicine>(Errors.DomainErrors.InvalidValuesError);

        return new VisitMedicine(0, visitId, medicineId, number);
    }
    #endregion

    #endregion
}
