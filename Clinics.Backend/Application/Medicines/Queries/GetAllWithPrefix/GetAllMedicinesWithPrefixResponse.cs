using Domain.Entities.Medicals.Medicines;

namespace Application.Medicines.Queries.GetAllWithPrefix;

public class GetAllMedicinesWithPrefixResponse 
{
    public class GetAllMedicinesWithPrefixResponseItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Form { get; set; } = null!;
        public int Amount { get; set; }
        public decimal Dosage { get; set; }
    }
    public ICollection<GetAllMedicinesWithPrefixResponseItem> Medicines { get; set; } = null!;

    public static GetAllMedicinesWithPrefixResponse GetResponse(ICollection<Medicine> medicines)
    {
        List<GetAllMedicinesWithPrefixResponseItem> result = new();
        foreach (Medicine medicine in medicines)
        {
            result.Add(new GetAllMedicinesWithPrefixResponseItem
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Form = medicine.MedicineForm.Name,
                Amount = medicine.Amount,
                Dosage = medicine.Dosage
            });
        }
        return new GetAllMedicinesWithPrefixResponse
        {
            Medicines = result
        };
    }


}
