using Domain.Entities.People.Employees.Relations.EmployeeFamilyMembers;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class EmployeeFamilyMembersRepository : Repositroy<EmployeeFamilyMember>, IEmployeeFamilyMembersRepository
{

    #region CTOR DI for context
    public EmployeeFamilyMembersRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion

    #region Create method
    public override Task<Result<EmployeeFamilyMember>> CreateAsync(EmployeeFamilyMember entity)
    {
        _context.Entry(entity.Role).State = EntityState.Unchanged;
        return base.CreateAsync(entity);
    }
    #endregion
}
