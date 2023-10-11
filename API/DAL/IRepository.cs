using System.Linq.Expressions;

namespace API.DAL
{

    public interface IRepository<TEntity> where TEntity : class
    {
         Task<IEnumerable<TEntity>> GetAllAsync(
            List<Expression<Func<TEntity, bool>>> filters = null,
            Expression<Func<TEntity, object>> orderBy = null,
            bool reverseOrder = false,
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
