using Domain.Primitives;

namespace Persistence.SeedDatabase;

public interface ISeed<TEntity> where TEntity : Entity
{
    public Task Seed();
}
