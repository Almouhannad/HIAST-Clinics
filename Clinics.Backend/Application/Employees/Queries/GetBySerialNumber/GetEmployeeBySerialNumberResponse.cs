using Domain.Entities.People.Employees;

namespace Application.Employees.Queries.GetBySerialNumber;

public class GetEmployeeBySerialNumberResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string SerialNumber { get; set; } = null!;
    public string CenterStatus { get; set; } = null!;

    public static GetEmployeeBySerialNumberResponse GetResponse(Employee employee)
    {
        return new GetEmployeeBySerialNumberResponse
        {
            Id = employee.Id,
            FirstName = employee.Patient.PersonalInfo.FirstName,
            MiddleName = employee.Patient.PersonalInfo.MiddleName,
            LastName = employee.Patient.PersonalInfo.LastName,
            Gender = employee.Patient.Gender.Name,
            DateOfBirth = employee.Patient.DateOfBirth,
            SerialNumber = employee.SerialNumber,
            CenterStatus = employee.CenterStatus

        };
    }
}
