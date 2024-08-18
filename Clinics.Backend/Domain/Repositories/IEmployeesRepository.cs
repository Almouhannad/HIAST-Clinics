using Domain.Entities.People.Employees;
using Domain.Repositories.Base;
using Domain.Shared;

namespace Domain.Repositories;

public interface IEmployeesRepository : IRepository<Employee>
{
    #region Get by serial number
    public Task<Result<Employee>> GetEmployeeBySerialNumberAsync(string serialNumber);

    #endregion
}
