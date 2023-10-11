using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.DAL.imlementations
{


    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(SpaceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }



        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await this.SaveAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await this.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
            await this.SaveAsync();
        }

        public async Task ClearAllAsync()
        {
            _dbSet.RemoveRange(await _dbSet.ToListAsync());
            await this.SaveAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
             List<Expression<Func<TEntity, bool>>> filters = null,
             Expression<Func<TEntity, object>> orderBy = null,
             bool reverseOrder = false,
             List<Expression<Func<TEntity, object>>> includeProperties = null,
             int? skip = null,
             int? take = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            if (orderBy != null)
            {
                if (reverseOrder)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }



        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
