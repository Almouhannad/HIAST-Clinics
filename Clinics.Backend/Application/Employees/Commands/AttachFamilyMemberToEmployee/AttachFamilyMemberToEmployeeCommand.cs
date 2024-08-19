using Application.Abstractions.CQRS.Commands;

namespace Application.Employees.Commands.AttachFamilyMemberToEmployee;

public class AttachFamilyMemberToEmployeeCommand : ICommand
{
    public string EmployeeSerialNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;

    public string FamilyRole { get; set; } = null!;

}
