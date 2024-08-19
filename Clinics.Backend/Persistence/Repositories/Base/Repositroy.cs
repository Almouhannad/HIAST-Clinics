using Domain.Errors;
using Domain.Primitives;
using Domain.Repositories.Base;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Specifications.Base;
using Persistence.Repositories.Specifications.Evaluator;

namespace Persistence.Repositories.Base;

public class Repositroy<TEntity> : IRepository<TEntity> where TEntity : Entity
{

    #region Ctor DI for context

    protected readonly ClinicsDbContext _context;

    public Repositroy(ClinicsDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Apply specification
    protected IQueryable<TEntity> ApplySpecification (Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), specification);
    }
    #endregion

    // CRUD operations

    #region Create operation

    public virtual void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public virtual async Task<Result<TEntity>> CreateWithEntityResultAsync (TEntity entity)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return Result.Failure<TEntity>(PersistenceErrors.UnableToCompleteTransaction);
        }
        return Result.Success<TEntity>(entry.Entity);
    }

    #endregion

    #region Read operations

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    #endregion

    #region Update operation

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    #endregion

    #region Delete operation

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    #endregion

}
