using Domain.Entities.People.Employees;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Employees;

public class EmployeesRepository : Repositroy<Employee>, IEmployeesRepository
{
    public EmployeesRepository(ClinicsDbContext context) : base(context) { }

    #region Create method
    public override Task<Result<Employee>> CreateAsync(Employee entity)
    {
        _context.Entry(entity.Patient.Gender).State = EntityState.Unchanged;
        return base.CreateAsync(entity);

    }
    #endregion

    #region Read methods
    public override async Task<Result<Employee>> GetByIdAsync(int id)
    {
        try
        {
            var query = _context.Set<Employee>()
                .Where(employee => employee.Id == id);
            var result = await query.FirstAsync();
            return await GetEmployeeBySerialNumberAsync(result.SerialNumber);
        }
        catch (Exception)
        {
            return Result.Failure<Employee>(PersistenceErrors.NotFound);
        }
    }
    #endregion

    #region Get by serial Number
    public async Task<Result<Employee>> GetEmployeeBySerialNumberAsync(string serialNumber)
    {
        var query = _context.Set<Employee>()
            .Where(employee => employee.SerialNumber == serialNumber)
            .Include(employee => employee.Patient)
                .ThenInclude(patient => patient.PersonalInfo)
            .Include(employee => employee.Patient)
                .ThenInclude(patient => patient.Gender);

        var result = await query.ToListAsync();
        if (result.Count != 1)
            return Result.Failure<Employee>(DomainErrors.SerialNumberNotFound);
        return Result.Success(result.First());
    }

    #endregion
}
