using Domain.Entities.People.Employees;
using Domain.Repositories;
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
}
