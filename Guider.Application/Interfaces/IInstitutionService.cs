using Guider.Application.Models.DTOs;
using Guider.Application.Models.Requests;
using Guider.Domain.Entities;

namespace Guider.Application.Interfaces
{
    public interface IInstitutionService
    {
        InstitutionDTO GetInstitutionDto(Institution institution);
        Task CreateAsync(CreateInstitutionReq req);
        Task<IList<Institution>> GetAllAsync();
        Task<Institution> GetByIdAsync(Guid id);
        Task UpdateAsync(UpdateInstitutionReq req, Institution institution);
        Task DeleteAsync(Guid id);
    }
}