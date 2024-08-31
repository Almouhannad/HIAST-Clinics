using Domain.Entities.People.Employees;
using Domain.Shared;

namespace EmployeesAPI.Services;

public interface IEmployeesAPIServices
{
    public Task<Result<ICollection<Employee>>> GetAll();
}
