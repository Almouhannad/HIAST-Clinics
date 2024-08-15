using Domain.Primitives;

namespace Domain.Entities.People.Employees.Shared;

// TODO: Convert to a value object containig value objects
public sealed class EmployeeAdditionalInfo(int id) : Entity(id)
{
    #region Properties

    public DateOnly? StartDate { get; set; }

    public string? AcademicQualification { get; set; }

    public string? WorkPhone { get; set; }

    public string? Location { get; set; }

    public string? Specialization { get; set; }

    public string? JobStatus { get; set; }

    public string? ImageUrl { get; set; }

    #endregion
}
