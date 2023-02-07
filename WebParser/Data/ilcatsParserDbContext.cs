using Microsoft.EntityFrameworkCore;
using WebParser.Models;

namespace WebParser.Data
{
    class ilcatsParserDbContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Complectation> Complectations { get; set; }
        public DbSet<PartsGroup> PartsGroups { get; set; }
        public DbSet<PartsSubGroup> PartsSubGroups { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Model>().HasIndex(m => m.Code).IsUnique();
            builder.Entity<Model>().Ignore(m => m.ComplecationUrl);

            builder.Entity<Complectation>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Complectation>().Ignore(c => c.GroupPartUrl);

            builder.Entity<PartsGroup>().Ignore(p => p.PartsSubGroupUrl);

            builder.Entity<PartsSubGroup>().Ignore(p => p.PartsUrl);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ilcats;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
