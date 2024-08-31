using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Shared;

namespace EmployeesAPI.Contracts;

public class EmployeeResponse
{
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DateOfBirth { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public string CenterStatus { get; set; } = null!;
    public string Id { get; set; } = null!;

    public Result<Employee> GetEmployee()
    {
        DateOnly dateOfBirth=new();
        var dateOfBirthResult = DateOnly.TryParse(DateOfBirth, out dateOfBirth);

        if (!dateOfBirthResult)
            return Result.Failure<Employee>(DomainErrors.InvalidValuesError);

        var employeeCreateResult = Employee.Create(FirstName, MiddleName, LastName, dateOfBirth, Gender, SerialNumber, CenterStatus);

        if (employeeCreateResult.IsFailure)
            return Result.Failure<Employee>(employeeCreateResult.Error);

        return employeeCreateResult.Value;
    }
}
