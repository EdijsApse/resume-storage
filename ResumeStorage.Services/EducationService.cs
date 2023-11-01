using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Data;

namespace ResumeStorage.Services
{
    public class EducationService : EntityService<Education>, IEducationService
    {
        public EducationService(IResumeDbContext context) : base(context)
        {
        }

        public List<Education> GetBasicProfileEducations(int basicProfileId)
        {
            return _context.Educations.Where(education => education.BasicProfileId == basicProfileId).ToList();
        }
    }
}
