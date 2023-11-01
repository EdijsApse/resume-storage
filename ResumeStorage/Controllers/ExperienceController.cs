using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;
using ResumeStorage.Services;

namespace ResumeStorage.Controllers
{
    public class ExperienceController : BaseController
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService, IMapper mapper) : base(mapper)
        {
            _experienceService = experienceService;
        }

        [Route("Resume/{basicProfileId:int}/Experience/Create")]
        public IActionResult Create(int basicProfileId)
        {
            var experiences = _experienceService
                .GetBasicProfileExperiences(basicProfileId)
                .Select(exp => _mapper.Map<ExperienceViewModel>(exp))
                .ToList();

            return View(new ExperienceListViewModel { ListOfExperiences = experiences, ResumeId = basicProfileId });
        }

        [HttpPost]
        [Route("Resume/{basicProfileId:int}/Experience/Create")]
        public IActionResult Store(int basicProfileId, List<ExperienceViewModel> listOfExperiences)
        {
            if (ModelState.IsValid)
            {
                listOfExperiences.ForEach(experience =>
                {
                    var mapped = _mapper.Map<Experience>(experience);

                    if (experience.Id == 0) _experienceService.Create(mapped);
                    else _experienceService.Update(mapped);
                });

                TempData["success"] = "List of experiences updated!";

                return Redirect($"/Resume/View/{basicProfileId}");
            }

            return View("Create", new ExperienceListViewModel { ListOfExperiences = listOfExperiences, ResumeId = basicProfileId });
        }

        [HttpPost]
        [Route("Resume/{basicProfileId:int}/Experience/Delete")]
        public IActionResult Delete(int basicProfileId, int id)
        {
            var experience = _experienceService.Query().Where(experience => experience.Id == id && experience.BasicProfileId == basicProfileId).First();

            if (experience == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Experience not found!"
                });
            }

            _experienceService.Delete(experience);

            return Ok(new
            {
                success = true,
                message = "List updated!"
            });
        }
    }
}
