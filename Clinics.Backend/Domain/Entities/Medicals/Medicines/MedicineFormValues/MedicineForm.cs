using Domain.Exceptions.InvalidValue;
using Domain.Primitives;

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
    public static MedicineForm Create(string name, int? id)
    {
        if (name is null)
            throw new InvalidValuesDomainException<MedicineForm>();

        if (id is not null)
        {
            if (id < 0)
                throw new InvalidValuesDomainException<MedicineForm>();
            return new MedicineForm(id.Value, name);
        }
        return new MedicineForm(0, name);
    }
    #endregion

    #endregion

}
