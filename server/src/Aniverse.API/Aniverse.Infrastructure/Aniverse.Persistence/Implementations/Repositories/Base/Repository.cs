using Aniverse.Core.Repositories.Abstraction.Base;
using Aniverse.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aniverse.Persistence.Implementations.Repositories.Base
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, new()
    {
        private readonly AniverseDbContext _context;

        public Repository(AniverseDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var newEntity = await _context.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
            return newEntity.Entity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            if (!tracking)
                query = Table.AsNoTracking();
            return predicate is null
                ? await query.ToListAsync()
                : await query.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TOrderBy>(int page, int size, Expression<Func<TEntity, TOrderBy>> orderBy, Expression<Func<TEntity, bool>> predicate = null, bool isOrderBy = true, bool tracking = true, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            if (!tracking)
                query = Table.AsNoTracking();
            return predicate is null
                ? await query.ToListAsync()
                : isOrderBy ?
                await query.Where(predicate).OrderBy(orderBy).Skip((page - 1) * size).Take(size).ToListAsync()
                :
                await query.Where(predicate).OrderByDescending(orderBy).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, bool tracking = true, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            if (!tracking)
                query = Table.AsNoTracking();
            return predicate is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(predicate).FirstOrDefaultAsync();
        }
        public TEntity Remove(TEntity entity)
        {
            return _context.Set<TEntity>().Remove(entity).Entity;
        }

        public async Task<TEntity> RemoveAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }
        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

    }
}
