using Domain.Primitives;

namespace Domain.Repositories.Base
{
    // CRUD operations
    public interface IRepository<TEntity>
        where TEntity : Entity
    {

        #region Create operation

        public Task<TEntity> CreateAsync(TEntity entity);

        #endregion

        #region Read operations

        public Task<TEntity?> GetByIdAsync(int id);

        public Task<ICollection<TEntity>> GetAllAsync();

        #endregion

        #region Update oprtation

        public Task<TEntity> UpdateAsync(TEntity entity);

        #endregion

        #region Delete operation

        public Task DeleteAsync(int id);

        #endregion
    }
}
