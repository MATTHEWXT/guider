
using System.Linq.Expressions;


namespace Guider.Domain.Core.Specifications
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; private set; }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<T, object>>>();
        }

        public virtual void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
    }
}
