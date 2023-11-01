using Microsoft.EntityFrameworkCore;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Data;

namespace ResumeStorage.Services
{
    public class ExperienceService : EntityService<Experience>, IExperienceService
    {
        public ExperienceService(IResumeDbContext context) : base(context)
        {
        }

        public List<Experience> GetBasicProfileExperiences(int basicProfileId)
        {
            return _context.Experiences
                .Where(exp => exp.BasicProfile.Id == basicProfileId)
                .Include(exp => exp.BasicProfile)
                .ToList();
        }
    }
}
