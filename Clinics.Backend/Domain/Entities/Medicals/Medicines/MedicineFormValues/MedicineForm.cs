using Domain.Primitives;

namespace Domain.Entities.Medicals.Medicines.MedicineFormValues;

public sealed class MedicineForm(int id) : Entity(id)
{
    #region Properties

    public string Name { get; set; } = null!;

    #endregion
}
