using Guider.Domain.Core.Models;
using Guider.Domain.Core.Repositories;
using Guider.Domain.Core.Specifications;
using Guider.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Guider.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> FirstOrDefaultAsync(IBaseSpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync() ?? throw new InvalidOperationException("Entity not found");
        }

        public async Task<bool> AnyAsync(IBaseSpecification<T> spec)
        {
            return await ApplySpecification(spec).AnyAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task AddListAsync(IList<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntitiesAsync(IList<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IList<T>> ListAsync(IBaseSpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        public async Task<T> GetByIdAsync(Guid id)
        {
           return await _dbContext.Set<T>().FindAsync(id) ?? throw new InvalidOperationException("Entity not found by Id"); ;
        }

        public async Task UpdateAsync(T entity)
        {
           _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(IBaseSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
