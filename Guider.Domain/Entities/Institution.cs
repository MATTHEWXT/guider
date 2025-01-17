using Guider.Domain.Core.Models;
using System.Net;
using System.Xml.Linq;

namespace Guider.Domain.Entities
{
    public class Institution : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public string? Description { get; set; }
        public Category Category { get; set; } = null!;
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public Institution() { }

        public Institution(Guid categoryId, string name, string address, string? desc)
        {
            CategoryId = categoryId;
            Name = name;
            Address = address;
            Description = desc;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Institution name is required.");
            else if (string.IsNullOrWhiteSpace(Address))
                throw new ArgumentException("The address is required.");
        }
    }
}
