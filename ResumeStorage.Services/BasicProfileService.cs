using Microsoft.EntityFrameworkCore;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Data;

namespace ResumeStorage.Services
{
    public class BasicProfileService : EntityService<BasicProfile>, IBasicProfileService
    {
        public BasicProfileService(IResumeDbContext context) : base(context)
        {
        }

        public BasicProfile GetFullResume(int id)
        {
            return _context.BasicProfiles
                .Include(profile => profile.ExperiencesList)
                .Include(profile => profile.EducationsList)
                .FirstOrDefault(profile => profile.Id == id);
        }
    }
}
