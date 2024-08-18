using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class EmployeesRepository : Repositroy<Employee>, IEmployeesRepository
{
    public EmployeesRepository(ClinicsDbContext context) : base(context) {}

    #region Create method
    public override void Create(Employee entity)
    {
        _context.Entry(entity.Patient.Gender).State = EntityState.Unchanged;
        _context.Set<Employee>().Add(entity);

    }
    #endregion

    #region Get by serial Number
    public async Task<Result<Employee>> GetEmployeeBySerialNumberAsync (string serialNumber)
    {
        var all = await _context.Set<Employee>().Where(employee => employee.SerialNumber == serialNumber).ToListAsync();
        if (all.Count != 1)
            return Result.Failure<Employee>(PersistenceErrors.NotFound);
        return Result.Success<Employee>(all.First());
    }
    #endregion
}
