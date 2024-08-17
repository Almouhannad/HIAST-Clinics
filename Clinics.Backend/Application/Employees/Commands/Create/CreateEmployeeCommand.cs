using Application.Abstractions.CQRS.Commands;

namespace Application.Employees.Commands.Create;

public class CreateEmployeeCommand : ICommand
{
    // Future update: Employees data will be fetched from ID system's API

    #region Personal info
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    #endregion

    #region Patient info
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
    #endregion

    #region Employee info
    public string SerialNumber { get; set; } = null!;
    public string CenterStatus { get; set; } = null!;
    #endregion

    #region Optional fields
    public DateOnly? StartDate { get; set; } = null;
    public string? AcademicQualification { get; set; } = null;
    public string? WorkPhone { get; set; } = null;
    public string? Location { get; set; } = null;
    public string? Specialization { get; set; } = null;
    public string? JobStatus { get; set; } = null;


    #endregion

}
