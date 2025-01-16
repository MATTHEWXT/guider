using Guider.Domain.Core.Models;

namespace Guider.Domain.Entities
{
    public class Teg : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Institution> Institutions { get; set; } = new List<Institution>();

        public Teg() { }

        public Teg(string name, string desc) {
            Name = name;
            Description = desc;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Teg name is required.");
        }
    }
}
