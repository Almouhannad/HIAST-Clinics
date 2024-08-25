using Application.Abstractions.CQRS.Commands;

namespace Application.WaitingList.Commands.SendWaitingListRecordToDoctor;

public class SendWaitingListRecordToDoctorCommand : ICommand
{
    public int WaitingListRecordId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
}
