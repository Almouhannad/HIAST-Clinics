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
    protected IQueryable<TEntity> ApplySpecification(Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<TEntity>(), specification);
    }
    #endregion

    // CRUD operations

    #region Create operation

    public virtual async Task<Result<TEntity>> CreateAsync(TEntity entity)
    {
        try
        {
            var createdEntity = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result.Success<TEntity>(createdEntity.Entity);
        }
        catch (Exception)
        {
            return Result.Failure<TEntity>(PersistenceErrors.UnableToCreate);
        }
    }

    #endregion

    #region Read operations

    public virtual async Task<Result<TEntity>> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstAsync(e => e.Id == id);
            return Result.Success<TEntity>(entity);
        }
        catch (Exception)
        {
            return Result.Failure<TEntity>(PersistenceErrors.NotFound);
        }

    }

    public virtual async Task<Result<ICollection<TEntity>>> GetAllAsync()
    {
        try
        {
            var entites = await _context.Set<TEntity>().ToListAsync();
            return Result.Success<ICollection<TEntity>>(entites);
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<TEntity>>(PersistenceErrors.NotFound);
        }

    }

    #endregion

    #region Update operation
    public virtual async Task<Result> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(PersistenceErrors.UnableToUpdate);
        }
    }
    #endregion

    #region Delete operation
    public virtual async Task<Result> DeleteAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(PersistenceErrors.UnableToDelete);
        }
    }
    #endregion

}
