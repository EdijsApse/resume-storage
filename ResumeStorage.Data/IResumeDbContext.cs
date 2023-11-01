using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ResumeStorage.Core.Models;

namespace ResumeStorage.Data
{
    public interface IResumeDbContext
    {
        public DbSet<BasicProfile> BasicProfiles { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        int SaveChanges();

        DbSet<T> Set<T>() where T : class;

        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
