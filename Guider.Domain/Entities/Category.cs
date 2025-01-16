using Guider.Domain.Core.Models;

namespace Guider.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Institution> Institutions { get; set; } = new List<Institution>();

        public Category() { }

        public Category(string name, string? desc) {
            Name = name;
            Description = desc;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Category name is required.");
        }
    }
}
