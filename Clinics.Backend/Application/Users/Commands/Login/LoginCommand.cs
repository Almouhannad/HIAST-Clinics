using Application.Abstractions.CQRS.Commands;

namespace Application.Users.Commands.Login;

public class LoginCommand : ICommand<string>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
