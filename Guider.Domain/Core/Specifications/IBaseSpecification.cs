using System.Linq.Expressions;

namespace Guider.Domain.Core.Specifications
{
    public interface IBaseSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        void AddInclude(Expression<Func<T, object>> include);
    }
}