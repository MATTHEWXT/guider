using AutoMapper;
using Guider.Application.Interfaces;
using Guider.Application.Models.DTOs;
using Guider.Domain.Core.Repositories;
using Guider.Domain.Core.Specifications;
using Guider.Domain.Entities;

namespace Guider.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IBaseRepositoryProvider _provider;
        private readonly IMapper _mapper;

        public TagService(IBaseRepositoryProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public Tag GetTag(TagDTO tag)
        {
            return _mapper.Map<Tag>(tag);
        }

        public async Task<IEnumerable<Tag>> CreateTags(IEnumerable<TagDTO> tags)
        {
            IEnumerable<string> tagNames = tags.Select(t => t.Name).Distinct().ToList();

            var existingTags = await _provider.Repository<Tag>()
                .ListAsync(TagSpecification.GetTagsByNames(tagNames));

            var missingTag = tags.Where(t => !existingTags.Any(existingTag => existingTag.Name == t.Name))
                .Select(t => new Tag(t.Name, t.Description))
                .ToList();

            try
            {
                await _provider.Repository<Tag>().AddListAsync(missingTag);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding tags", ex);
            }

            return existingTags.Concat(missingTag);
        }
    }
}
