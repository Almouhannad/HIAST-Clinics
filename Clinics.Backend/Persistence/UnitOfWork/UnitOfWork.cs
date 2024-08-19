using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using System.Data;

namespace Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClinicsDbContext _context;

    public UnitOfWork(ClinicsDbContext context)
    {
        _context = context;
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
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
            throw;
        }
    }
}
