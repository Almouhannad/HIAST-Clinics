using Application.Abstractions.CQRS.Commands;

namespace Application.WaitingList.Commands.CreateWaitingListRecord;

public class CreateWaitingListRecordCommand : ICommand
{
    public string SerialNumber { get; set; } = null!;
}
