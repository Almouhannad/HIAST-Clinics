using Domain.Entities.Identity.Users;
using Persistence.Repositories.Specifications.Base;
using System.Linq.Expressions;

namespace Persistence.Repositories.Users;

public class FullUserSpecification : Specification<User>
{
    public FullUserSpecification(Expression<Func<User, bool>>? criteria) : base(criteria)
    {
        AddInclude(user => user.Role);
    }
}
