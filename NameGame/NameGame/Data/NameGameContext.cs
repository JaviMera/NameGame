using Microsoft.EntityFrameworkCore;
using NameGame.Models.Domain;

namespace NameGame.Data
{
    public sealed class NameGameContext : DbContext
    {
        public NameGameContext(DbContextOptions<NameGameContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Headshot> Headshots { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
    }
}
