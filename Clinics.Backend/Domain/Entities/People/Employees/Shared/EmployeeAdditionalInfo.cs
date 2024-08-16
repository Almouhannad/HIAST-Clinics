using Domain.Primitives;

namespace Domain.Entities.People.Employees.Shared;

// TODO: Convert to a value object containig value objects
public sealed class EmployeeAdditionalInfo : Entity
{

    #region Private ctor
    private EmployeeAdditionalInfo(int id) : base(id)
    {
    }
    private EmployeeAdditionalInfo(int id,
        DateOnly? startDate,
        string? academicQualification,
        string? workPhone,
        string? location,
        string? specialization,
        string? jobStatus,
        string? imageUrl
        )
        : base(id)
    {
        StartDate = startDate;
        AcademicQualification = academicQualification;
        WorkPhone = workPhone;
        Location = location;
        Specialization = specialization;
        JobStatus = jobStatus;
        ImageUrl = imageUrl;
    }


    #endregion

    #region Properties

    public DateOnly? StartDate { get; set; }

    public string? AcademicQualification { get; set; }

    public string? WorkPhone { get; set; }

    public string? Location { get; set; }

    public string? Specialization { get; set; }

    public string? JobStatus { get; set; }

    public string? ImageUrl { get; set; }

    #endregion

    #region Methods

    #region Static factory
    public static EmployeeAdditionalInfo Create(DateOnly? startDate,
        string? academicQualification,
        string? workPhone,
        string? location,
        string? specialization,
        string? jobStatus,
        string? imageUrl)
    {
        return new EmployeeAdditionalInfo(0,
            startDate, academicQualification, workPhone, location, specialization, jobStatus, imageUrl);
    }
    #endregion

    #endregion
}
