using Application.Abstractions.CQRS.Commands;

namespace Application.Doctors.Commands.AddPhoneNumberByUserId;

public class AddPhoneNumberByUserIdCommand : ICommand
{
    public int DoctorUserId { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;

}
