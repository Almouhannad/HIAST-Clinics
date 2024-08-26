using Domain.Entities.Medicals.Medicines;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Medicines;

public class MedicinesRepository : Repositroy<Medicine>, IMedicinesRepository
{
    #region CTOR DI for context
    public MedicinesRepository(ClinicsDbContext context) : base(context)
    {
    }
    #endregion


    #region Get all with prefix
    public async Task<Result<ICollection<Medicine>>> GetAllWithPrefix(string? prefix = null)
    {
        try
        {
            var query = _context.Set<Medicine>().AsQueryable();
            if (prefix is not null)
            {
                query = query.Where(medicine =>
                medicine.Name.ToLower().StartsWith(prefix.ToLower()));
            }
            query = query.OrderBy(medicine => medicine.Name)
                .Include(medicine => medicine.MedicineForm);
            return await query.ToListAsync();
        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Medicine>>(PersistenceErrors.Unknown);
        }
    }
    #endregion
}
