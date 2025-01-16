using Guider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Guider.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Teg> Tegs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Institutions)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<Teg>()
                .HasMany(t => t.Institutions)
                .WithMany(i => i.Tegs);

            base.OnModelCreating(modelBuilder);
        }
    }
}
