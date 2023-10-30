using ResumeStorage.Core.Models;

namespace ResumeStorage.Core.Services
{
    public interface IEducationService : IEntityService<Education>
    {
        List<Education> GetBasicProfileEducations(int basicProfileId);
    }
}
