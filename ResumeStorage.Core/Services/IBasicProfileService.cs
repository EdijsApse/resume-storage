using ResumeStorage.Core.Models;

namespace ResumeStorage.Core.Services
{
    public interface IBasicProfileService : IEntityService<BasicProfile>
    {
        BasicProfile GetFullResume(int id);
    }
}
