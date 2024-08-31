using Domain.Entities.Medicals.Medicines;
using Domain.Shared;

namespace MedicinesAPI.Contrants;

public class MedicineResponse
{
    public string Form { get; set; } = null!;
    public int Amount { get; set; }
    public string Name { get; set; } = null!;
    public decimal Dosage { get; set; }

    public string Id { get; set; } = null!;

    public Result<Medicine> GetMedicine()
    {
        var medicineCreateResult = Medicine.Create(Form, Amount, Name, Dosage);
        if (medicineCreateResult.IsFailure)
            return Result.Failure<Medicine>(medicineCreateResult.Error);
        return medicineCreateResult.Value;
    }
}
