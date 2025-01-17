using Guider.Application.Models.DTOs;
using Guider.Domain.Entities;

namespace Guider.Application.Interfaces
{
    public interface ITagService
    {
        Tag GetTag(TagDTO tag);
        Task<IEnumerable<Tag>> CreateTags(IEnumerable<TagDTO> tags);
    }
}