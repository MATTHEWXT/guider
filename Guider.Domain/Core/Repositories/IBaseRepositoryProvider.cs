using Guider.Domain.Core.Models;

namespace Guider.Domain.Core.Repositories
{
    public interface IBaseRepositoryProvider
    {
        IBaseRepository<T> Repository<T>() where T : BaseEntity;
    }
}
