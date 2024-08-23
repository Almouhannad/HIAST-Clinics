using Application.Abstractions.CQRS.Commands;

namespace Application.Users.Commands.UpdateDoctorPersonalInfo;

public class UpdateDoctorPersonalInfoCommand : ICommand
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
