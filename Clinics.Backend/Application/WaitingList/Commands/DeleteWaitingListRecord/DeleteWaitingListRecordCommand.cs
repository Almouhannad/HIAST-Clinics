using Application.Abstractions.CQRS.Commands;

namespace Application.WaitingList.Commands.DeleteWaitingListRecord;

public class DeleteWaitingListRecordCommand : ICommand
{
    public int Id { get; set; }
}
