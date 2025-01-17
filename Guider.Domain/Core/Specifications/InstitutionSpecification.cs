using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Domain.Core.Specifications
{
    public static class InstitutionSpecification
    {
        public static BaseSpecification<Institution> GetInstitutionByName(string name)
        {
            return new BaseSpecification<Institution>(i => i.Name == name);
        }

        public static BaseSpecification<Institution> GetInstitutionAndIncludes()
        {
            var specification = new BaseSpecification<Institution>(null!);
            specification.Includes.Add(i => i.Tags);

            return specification;
        }
        public static BaseSpecification<Institution> GetInstitutionByIdAndIncludes(Guid id)
        {
            var specification = new BaseSpecification<Institution>(i => i.Id == id);
            specification.Includes.Add(i => i.Tags);

            return specification;
        }
    }
}
