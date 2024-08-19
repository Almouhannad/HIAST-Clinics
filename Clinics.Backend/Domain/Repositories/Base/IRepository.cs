using Domain.Primitives;
using Domain.Shared;

namespace Domain.Repositories.Base
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        // CRUD operations

        #region Create operation

        public Task<Result<TEntity>> CreateAsync(TEntity entity);

        #endregion

        #region Read operations

        public Task<Result<TEntity>> GetByIdAsync(int id);

        public Task<Result<ICollection<TEntity>>> GetAllAsync();

        #endregion

        #region Update oprtation

        public Task<Result> UpdateAsync(TEntity entity);

        #endregion

        #region Delete operation

        public Task<Result> DeleteAsync(TEntity entity);

        #endregion
    }
}
