using Domain.Exceptions.InvalidValue;

namespace Domain.Entities.Medicals.Medicines.MedicineFormValues;

public static class MedicineForms
{
    #region Constant values

    public static int Count => 2;
    public static MedicineForm Tablet
    {
        get
        {
            var result = MedicineForm.Create("حبوب", 1);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<MedicineForm>();
            return result.Value;
        }
    }

    public static MedicineForm Syrup
    {
        get
        {
            var result = MedicineForm.Create("شراب", 2);
            if (result.IsFailure)
                throw new InvalidValuesDomainException<MedicineForm>();
            return result.Value;
        }
    }

    #endregion
}
