using Guider.Domain.Core.Models;

namespace Guider.Domain.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task AddListAsync(IList<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteEntitiesAsync(IList<T> entities);
    }
}
