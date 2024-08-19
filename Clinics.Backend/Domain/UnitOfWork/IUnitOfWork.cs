using System.Data;

namespace Domain.UnitOfWork;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();

    public IDbTransaction BeginTransaction();
    // Note that type "IDbTranaction" is from System.Data
        // i.e. It's not related to any database system
}
