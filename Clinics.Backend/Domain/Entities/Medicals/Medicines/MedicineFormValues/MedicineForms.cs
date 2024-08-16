namespace Domain.Entities.Medicals.Medicines.MedicineFormValues;

public static class MedicineForms
{
    #region Constant id values

    public static MedicineForm Tablet => MedicineForm.Create("حبوب", 1);

    public static MedicineForm Syrup => MedicineForm.Create("شراب", 2);

    #endregion
}
