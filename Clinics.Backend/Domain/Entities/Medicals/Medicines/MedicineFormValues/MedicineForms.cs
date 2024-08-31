namespace Domain.Entities.Medicals.Medicines.MedicineFormValues;

public static class MedicineForms
{
    #region Constant values

    public static int Count => 2;

    private static readonly MedicineForm _tablet = MedicineForm.Create("حبوب", 1).Value;
    public static MedicineForm Tablet => _tablet;

    private static readonly MedicineForm _syrup = MedicineForm.Create("شراب", 2).Value;
    public static MedicineForm Syrup => _syrup;

    #endregion
}
