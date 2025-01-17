
using Guider.Domain.Entities;

namespace Guider.Domain.Core.Specifications
{
    public static class TagSpecification
    {
        public static BaseSpecification<Tag> GetTagByName(string name)
        {
            return new BaseSpecification<Tag>(t => t.Name == name);
        }
        public static BaseSpecification<Tag> GetTagsByNames(IEnumerable<string> names)
        {
            return new BaseSpecification<Tag>(t => names.Contains(t.Name));
        }

    }
}
