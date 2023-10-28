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
    }
}
