using Domain.Entities.People.FamilyMembers;
using Domain.Repositories;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class FamilyMembersRepository : Repositroy<FamilyMember>, IFamilyMembersRepository
{
    #region CTOR DI for context
    public FamilyMembersRepository(ClinicsDbContext context) : base(context) {}
    #endregion

}
