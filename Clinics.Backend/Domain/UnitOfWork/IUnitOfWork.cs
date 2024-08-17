namespace Domain.UnitOfWork;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}
