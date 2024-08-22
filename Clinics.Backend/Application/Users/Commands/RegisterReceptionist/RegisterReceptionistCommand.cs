using Application.Abstractions.CQRS.Commands;

namespace Application.Users.Commands.RegisterReceptionist;

public class RegisterReceptionistCommand : ICommand
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
