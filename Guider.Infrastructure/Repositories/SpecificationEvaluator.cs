using Guider.Domain.Core.Models;
using Guider.Domain.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Guider.Infrastructure.Repositories
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = inputQuery.Where(specification.Criteria);
            }

            if (specification.Includes != null)
            {
                query = specification.Includes.Aggregate(query,
                         (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
