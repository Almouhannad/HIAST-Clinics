using Application.Abstractions.CQRS.Commands;

namespace Application.Users.Commands.UpdateDoctorUser;

public class UpdateDoctorUserCommand : ICommand
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string? Password { get; set; } = null;
}
