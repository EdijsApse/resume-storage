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

                cfg.CreateMap<BasicProfile, ResumeViewModel>();

                cfg.CreateMap<BasicProfileViewModel, BasicProfile>()
                .ForMember(dest => dest.ExperiencesList, opt => opt.Ignore())
                .ForMember(dest => dest.EducationsList, opt => opt.Ignore());

                cfg.CreateMap<Experience, ExperienceViewModel>();

                cfg.CreateMap<ExperienceViewModel, Experience>()
                .ForMember(dest => dest.BasicProfile, opt => opt.Ignore());

                cfg.CreateMap<Education, EducationViewModel>();

                cfg.CreateMap<EducationViewModel, Education>()
                .ForMember(dest => dest.BasicProfile, opt => opt.Ignore());

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
