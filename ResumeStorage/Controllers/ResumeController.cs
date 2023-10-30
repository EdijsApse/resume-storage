using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;

namespace ResumeStorage.Controllers
{
    public class ResumeController : BaseController
    {
        private readonly IBasicProfileService _resumeService;

        public ResumeController(IMapper mapper, IBasicProfileService service) : base(mapper)
        {
            _resumeService = service;
        }

        public IActionResult Index()
        {
            var listOfResumes = _resumeService.Get().Select(details => _mapper.Map<BasicProfileViewModel>(details));

            return View(listOfResumes);
        }

        [Route("Resume/View/{id}")]
        public IActionResult View(int id)
        {
            var resume = _resumeService.GetFullResume(id);

            if (resume == null) return NotFound();

            return View(_mapper.Map<ResumeViewModel>(resume));
        }

        public IActionResult Delete(int id)
        {
            var profile = _resumeService.GetById(id);

            if (profile == null) return NotFound();

            _resumeService.Delete(profile);

            return RedirectToAction("Index");
        }
    }
}
