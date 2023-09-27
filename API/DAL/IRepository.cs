using System.Linq.Expressions;

namespace API.DAL
{

    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetWithFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task ClearAllAsync();
    }

}
