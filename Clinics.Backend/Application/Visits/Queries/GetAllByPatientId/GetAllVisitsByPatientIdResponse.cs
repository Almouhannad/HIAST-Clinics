using Domain.Entities.Visits;
using Domain.Entities.Visits.Relations.VisitMedicines;

namespace Application.Visits.Queries.GetAllByPatientId;

public class GetAllVisitsByPatientIdResponse
{
    public class MedicineView
    {
        public string Name { get; set; } = null!;
        public string Form { get; set; } = null!;
        public int Amount { get; set; }
        public decimal Dosage { get; set; }
        public int Number { get; set; } // Number in visit

    }

    public class GetAllVisitsByPatientIdResponseItem
    {
        public string DoctorName { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public DateOnly Date { get; set; }
        public ICollection<MedicineView> Medicines { get; set; } = null!;
    }

    public ICollection<GetAllVisitsByPatientIdResponseItem> Visits { get; set; } = null!;

    public static GetAllVisitsByPatientIdResponse GetResponse(ICollection<Visit> visits)
    {
        List<GetAllVisitsByPatientIdResponseItem> result = new();
        foreach (Visit visit in visits)
        {
            List<MedicineView> medicinesItem = new();
            foreach (VisitMedicine visitMedicine in visit.Medicines)
            {
                medicinesItem.Add(new MedicineView
                {
                    Name = visitMedicine.Medicine.Name,
                    Form = visitMedicine.Medicine.MedicineForm.Name,
                    Amount = visitMedicine.Medicine.Amount,
                    Dosage = visitMedicine.Medicine.Dosage,
                    Number = visitMedicine.Number
                });
            }
            result.Add(new GetAllVisitsByPatientIdResponseItem
            {
                DoctorName = visit.Doctor.PersonalInfo.FullName,
                Diagnosis = visit.Diagnosis,
                Date = visit.Date,
                Medicines = medicinesItem
            });
        }
        return new GetAllVisitsByPatientIdResponse
        {
            Visits = result
        };
    }


}
