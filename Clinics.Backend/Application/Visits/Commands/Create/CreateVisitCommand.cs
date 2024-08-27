using Application.Abstractions.CQRS.Commands;

namespace Application.Visits.Commands.Create;

public class CreateVisitCommand : ICommand
{
    public class CreateVisitCommandItem
    {
        public int MedicineId { get; set; }
        public int Number { get; set; }
    }
    public int DoctorUserId { get; set; }
    public int PatientId { get; set; }
    public string Diagnosis { get; set; } = null!;
    public ICollection<CreateVisitCommandItem> Medicines { get; set; } = null!;
}
