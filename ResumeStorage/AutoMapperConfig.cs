using AutoMapper;
using ResumeStorage.Core.Models;
using ResumeStorage.Models;

namespace ResumeStorage
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BasicProfile, BasicProfileViewModel>();
                cfg.CreateMap<BasicProfileViewModel, BasicProfile>();
            });

            // only during development, validate your mappings; remove it before release
            #if DEBUG
            configuration.AssertConfigurationIsValid();
            #endif
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            return configuration.CreateMapper();
        }
    }
}
