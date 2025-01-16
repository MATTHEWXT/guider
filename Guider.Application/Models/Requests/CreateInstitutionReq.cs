using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Models.Requests
{
    public class CreateInstitutionReq
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Teg> Tegs { get; set; } = new List<Teg>();
    }
}
