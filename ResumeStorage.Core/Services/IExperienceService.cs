using ResumeStorage.Core.Models;

namespace ResumeStorage.Core.Services
{
    public interface IExperienceService : IEntityService<Experience>
    {
        List<Experience> GetBasicProfileExperiences(int basicProfileId);
    }
}
