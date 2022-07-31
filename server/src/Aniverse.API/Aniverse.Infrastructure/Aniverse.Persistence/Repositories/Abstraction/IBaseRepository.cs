using Aniverse.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Aniverse.Persistence.Repositories.Abstraction
{
    public interface IBaseRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
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
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                        bool tracking = true,
                        params string[] include);
        Task<TEntity> GetAsync(string id,
                         bool tracking = true,
                         params string[] include);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Remove(TEntity entity);
        Task<TEntity> RemoveAsync(string id);
        TEntity Update(TEntity entity);
        Task<int> SaveAsync();
    }
}
