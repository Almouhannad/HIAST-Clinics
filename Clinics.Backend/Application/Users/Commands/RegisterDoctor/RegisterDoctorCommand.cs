using Application.Abstractions.CQRS.Commands;

namespace Application.Users.Commands.RegisterDoctor;

public class RegisterDoctorCommand : ICommand<RegisterDoctorResponse>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;

}
