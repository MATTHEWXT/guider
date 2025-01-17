using Guider.Domain.Core.Models;
using Guider.Domain.Core.Specifications;

namespace Guider.Domain.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> FirstOrDefaultAsync(IBaseSpecification<T> spec);
        Task<bool> AnyAsync(IBaseSpecification<T> spec);
        Task<T> GetByIdAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> ListAsync(IBaseSpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task AddListAsync(IList<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteEntitiesAsync(IList<T> entities);
    }
}
