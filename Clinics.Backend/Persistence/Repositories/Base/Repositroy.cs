using Domain.Primitives;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Base;

public class Repositroy<TEntity> : IRepository<TEntity> where TEntity : Entity
{

    #region Ctor DI for context

    private readonly ClinicsDbContext _context;

    public Repositroy(ClinicsDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Create operation

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        return await _context.Set<TEntity>().FirstAsync(e => e.Id == entity.Id);
    }

    #endregion

    #region Read operations

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync<TEntity>();
    }

    #endregion

    #region Update operation

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var query = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return query.Entity;
    }

    #endregion

    #region Delete operation

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is not null)
            _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

    }

    #endregion







}
