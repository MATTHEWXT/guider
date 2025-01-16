
using Guider.Domain.Core.Repositories;

namespace Guider.Application.Services
{
    public class InstitutionService
    {
        private readonly IBaseRepositoryProvider _provider;

        public InstitutionService(IBaseRepositoryProvider provider)
        {
            _provider = provider;
        }

        
    }
}
