using Microsoft.EntityFrameworkCore;
using ResumeStorage.Core.Models;

namespace ResumeStorage.Data
{
    public class ResumeDbContext : DbContext, IResumeDbContext
    {
        public DbSet<BasicProfile> BasicProfiles { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options) { }
    }
}
