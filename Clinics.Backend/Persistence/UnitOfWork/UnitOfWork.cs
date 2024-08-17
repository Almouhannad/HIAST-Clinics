using Domain.UnitOfWork;
using Persistence.Context;

namespace Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClinicsDbContext _context;

    public UnitOfWork(ClinicsDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            // TODO: Log errors using ILogger
            //throw;
        }
    }
}
