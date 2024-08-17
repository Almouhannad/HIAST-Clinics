using Domain.Primitives;
using System.Linq.Expressions;

namespace Persistence.Repositories.Specifications.Base;

public abstract class Specification<TEntity> where TEntity : Entity
{
    protected Specification(Expression<Func<TEntity, bool>>? criteria)
    {
        Criteria = criteria;
    }

    #region Where criteria

    public Expression<Func<TEntity, bool>>? Criteria { get; }

    #endregion

    #region Includes

    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

    #endregion

    #region Order by

    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    #endregion

    #region Add methods

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderByExpression = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
    {
        OrderByDescendingExpression = orderByDescendingExpression;
    }

    #endregion

}
