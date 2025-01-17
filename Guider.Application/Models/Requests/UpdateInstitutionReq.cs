using Guider.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Models.Requests
{
    public class UpdateInstitutionReq
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
