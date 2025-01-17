using AutoMapper;
using Guider.Application.Models.DTOs;
using Guider.Domain.Entities;

namespace Guider.Application.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Institution, InstitutionDTO>();
            CreateMap<InstitutionDTO, Institution>();
            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, Tag>();
        }
    }
}
