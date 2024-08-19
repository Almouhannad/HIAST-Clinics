using Domain.Primitives;
using Domain.Shared;

namespace Domain.Repositories.Base
{
    // Note that queries are async, but commands are NOT
        // Since the persist operation is done by UnitOfWork
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        // CRUD operations

        #region Create operation

        public void Create(TEntity entity);

        public Task<Result<TEntity>> CreateWithEntityResultAsync (TEntity entity);

        #endregion

        #region Read operations

        public Task<TEntity?> GetByIdAsync(int id);

        public Task<ICollection<TEntity>> GetAllAsync();

        #endregion

        #region Update oprtation

        public void Update(TEntity entity);

        #endregion

        #region Delete operation

        public void Delete(TEntity entity);

        #endregion
    }
}
