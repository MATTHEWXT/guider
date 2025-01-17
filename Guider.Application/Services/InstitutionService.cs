
using AutoMapper;
using Guider.Application.Interfaces;
using Guider.Application.Models.DTOs;
using Guider.Application.Models.Requests;
using Guider.Domain.Core.Repositories;
using Guider.Domain.Core.Specifications;
using Guider.Domain.Entities;

namespace Guider.Application.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IBaseRepositoryProvider _provider;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public InstitutionService(IBaseRepositoryProvider provider, ITagService tagService, IMapper mapper)
        {
            _provider = provider;
            _tagService = tagService;
            _mapper = mapper;
        }

        public InstitutionDTO GetInstitutionDto(Institution institution)
        {
            return _mapper.Map<InstitutionDTO>(institution);
        }

        public async Task CreateAsync(CreateInstitutionReq req)
        {

            bool isInstitutionExists = await _provider.Repository<Institution>()
                .AnyAsync(InstitutionSpecification.GetInstitutionByName(req.Name));

            if (isInstitutionExists)
            {
                throw new ApplicationException("Institution already exists");
            }

            Institution institution = new Institution(
                req.CategoryId,
                req.Name,
                req.Address,
                req.Description
                );
            institution.Validate();

            IEnumerable<Tag> tagsToAdd = await _tagService.CreateTags(req.Tags);
            institution.Tags.AddRange(tagsToAdd);

            try
            {
                await _provider.Repository<Institution>().AddAsync(institution);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding institution", ex);
            }
        }

        public async Task<IList<Institution>> GetAllAsync()
        {
            return await _provider.Repository<Institution>()
                .ListAsync(InstitutionSpecification.GetInstitutionAndIncludes());
        }

        public async Task<Institution> GetByIdAsync(Guid id)
        {
            return await _provider.Repository<Institution>()
                .FirstOrDefaultAsync(InstitutionSpecification.GetInstitutionByIdAndIncludes(id));
        }

        public async Task UpdateAsync(UpdateInstitutionReq req, Institution institution)
        {
            bool isInstitutionNameExists = await _provider.Repository<Institution>()
                .AnyAsync(InstitutionSpecification.GetInstitutionByName(req.Name));

            if (req.Name != institution.Name && isInstitutionNameExists) {
                throw new ApplicationException("Institution Name already exists");
            }

            institution.CategoryId = req.CategoryId;
            institution.Name = req.Name;
            institution.Address = req.Address;
            institution.Description = req.Description;

            var tags = await _tagService.CreateTags(req.Tags);

            institution.Tags = tags.ToList();

            await _provider.Repository<Institution>().UpdateAsync(institution);
        }

        public async Task DeleteAsync(Guid id)
        {
            var institution = await _provider.Repository<Institution>()
                .FirstOrDefaultAsync(InstitutionSpecification.GetInstitutionByIdAndIncludes(id));

            await _provider.Repository<Institution>().DeleteAsync(institution);
        }
    }
}
