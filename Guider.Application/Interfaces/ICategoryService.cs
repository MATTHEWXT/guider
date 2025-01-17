using Guider.Application.Models.Requests;

namespace Guider.Application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryReq req);
    }
}