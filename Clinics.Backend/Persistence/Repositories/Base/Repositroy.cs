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

    #region Apply specification

    #endregion

    #region CRUD

    #region Create operation

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var query = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return query.Entity;
    }

    #endregion

    #region Read operations

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
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

    #endregion

}
