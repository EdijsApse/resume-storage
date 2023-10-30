using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;

namespace ResumeStorage.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        private readonly IMapper _mapper;

        public ExperienceController(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        [Route("BasicProfile/{basicProfileId:int}/experience")]
        public IActionResult Index(int basicProfileId)
        {
            var experiences = _experienceService
                .GetBasicProfileExperiences(basicProfileId)
                .Select(exp => _mapper.Map<ExperienceViewModel>(exp));

            return View(experiences);
        }

        [Route("BasicProfile/{basicProfileId:int}/experience/create")]
        public IActionResult Create(int basicProfileId)
        {
            var experiences = _experienceService
                .GetBasicProfileExperiences(basicProfileId)
                .Select(exp => _mapper.Map<ExperienceViewModel>(exp))
                .ToList();

            return View(new ExperienceListViewModel { ListOfExperiences = experiences });
        }

        [HttpPost]
        [Route("BasicProfile/{basicProfileId:int}/experience/create")]
        public IActionResult Create(int basicProfileId, List<ExperienceViewModel> listOfExperiences)
        {
            if (ModelState.IsValid)
            {
                listOfExperiences.ForEach(exp =>
                {
                    var mapped = _mapper.Map<Experience>(exp);
                    _experienceService.Update(mapped);
                });

                return RedirectToAction("Index", new { basicProfileId = basicProfileId });
            }

            return View(new ExperienceListViewModel { ListOfExperiences = listOfExperiences });
        }
    }
}
