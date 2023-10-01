using System.Linq.Expressions;

namespace API.DAL
{

    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        List<Expression<Func<TEntity, object>>> includeProperties = null,
        int? skip = null,
        int? take = null);

        Task<TEntity> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task ClearAllAsync();
    }
}
