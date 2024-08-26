using Application.Abstractions.CQRS.Commands;

namespace Application.Doctors.Commands.ChangeStatusByUserId;

public class ChangeStatusByUserIdCommand : ICommand
{
    public int UserId { get; set; }
    public string Status { get; set; } = null!;
}
