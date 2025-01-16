

using Guider.Domain.Core.Models;
using Guider.Domain.Core.Repositories;
using Guider.Infrastructure.Data;

namespace Guider.Infrastructure.Repositories
{
    public class BaseRepositoryProvider : IBaseRepositoryProvider
    {
        private readonly AppDbContext _dbContext;

        public BaseRepositoryProvider(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_dbContext);
        }
    }
}
