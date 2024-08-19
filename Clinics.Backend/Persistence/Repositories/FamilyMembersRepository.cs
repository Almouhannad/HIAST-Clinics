using Domain.Entities.People.FamilyMembers;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class FamilyMembersRepository : Repositroy<FamilyMember>, IFamilyMembersRepository
{
    #region CTOR DI for context
    public FamilyMembersRepository(ClinicsDbContext context) : base(context) {}
    #endregion

    #region Create method
    public override Task<Result<FamilyMember>> CreateAsync(FamilyMember entity)
    {
        _context.Entry(entity.Patient.Gender).State = EntityState.Unchanged;
        return base.CreateAsync(entity);
    }
    #endregion

}
