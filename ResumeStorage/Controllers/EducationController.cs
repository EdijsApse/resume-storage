using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;

namespace ResumeStorage.Controllers
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IMapper mapper, IEducationService service) : base(mapper)
        {
            _educationService = service;
        }

        [Route("Resume/{basicProfileId:int}/Education/Create")]
        public IActionResult Create(int basicProfileId)
        {
            var educations = _educationService
                .GetBasicProfileEducations(basicProfileId)
                .Select(edu => _mapper.Map<EducationViewModel>(edu))
                .ToList();

            return View(new EducationListViewModel { ListOfEducations = educations, ResumeId = basicProfileId });
        }

        [HttpPost]
        [Route("Resume/{basicProfileId:int}/Education/Create")]
        public IActionResult Store(int basicProfileId, List<EducationViewModel> listOfEducations)
        {
            if (ModelState.IsValid)
            {
                listOfEducations.ForEach(education =>
                {
                    var mapped = _mapper.Map<Education>(education);

                    if (education.Id == 0) _educationService.Create(mapped);
                    else _educationService.Update(mapped);
                });

                return Redirect($"/Resume/View/{basicProfileId}");
            }

            return View("Create", new EducationListViewModel { ListOfEducations = listOfEducations, ResumeId = basicProfileId });
        }
    }
}
