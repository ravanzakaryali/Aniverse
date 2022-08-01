using System.Linq.Expressions;

namespace Aniverse.Core.Repositories.Abstraction.Base
{
    public interface IRepository<TEntity, TKey> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                bool tracking = true,
                                params string[] includes);
        Task<List<TEntity>> GetAllAsync<TOrderBy>(int page,
                                            int size,
                                            Expression<Func<TEntity, TOrderBy>> orderBy,
                                            Expression<Func<TEntity, bool>> predicate = null,
                                            bool isOrderBy = true,
                                            bool tracking = true,
                                            params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true, params string[] include);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<TEntity> RemoveAsync(TKey id);
        TEntity Update(TEntity entity);
        Task<int> SaveAsync();
    }
}
