using Domain.Entities.People.Employees;

namespace Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandResponse
{
    public int Id { get; set; }

    public static CreateEmployeeCommandResponse GetResponse(Employee employee)
    {
        return new CreateEmployeeCommandResponse { Id = employee.Id };
    }
}
