using System.Linq;
using System.Threading.Tasks;

namespace VSSUMMIT.Demo00.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> GetWithPagination(int page, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
