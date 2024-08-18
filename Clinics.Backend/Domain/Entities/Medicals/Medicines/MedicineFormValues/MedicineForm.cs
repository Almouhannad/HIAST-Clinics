using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Medicals.Medicines.MedicineFormValues;

public sealed class MedicineForm : Entity
{
    #region Private ctor
    private MedicineForm(int id) : base(id) { }

    private MedicineForm(int id, string name) : base(id)
    {
        Name = name;
    }
    #endregion

    #region Properties

    public string Name { get; set; } = null!;

    #endregion

    #region Methods

    #region Static factory
    public static Result<MedicineForm> Create(string name, int? id)
    {
        if (name is null)
            return Result.Failure<MedicineForm>(Errors.DomainErrors.InvalidValuesError);

        if (id is not null)
        {
            if (id < 0)
                return Result.Failure<MedicineForm>(Errors.DomainErrors.InvalidValuesError);
            return new MedicineForm(id.Value, name);
        }
        return new MedicineForm(0, name);
    }
    #endregion

    #endregion

}
