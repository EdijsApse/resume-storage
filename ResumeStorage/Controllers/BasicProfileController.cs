using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;

namespace ResumeStorage.Controllers
{
    public class BasicProfileController : Controller
    {
        private readonly IBasicProfileService _basicProfileService;

        private readonly IMapper _mapper;

        public BasicProfileController(IBasicProfileService basicProfileService, IMapper mapper)
        {
            _basicProfileService = basicProfileService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var listOfBasicDetails = _basicProfileService.Get().Select(profileDetail => _mapper.Map<BasicProfileViewModel>(profileDetail));

            return View(listOfBasicDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(BasicProfileViewModel basicProfile)
        {
            if (ModelState.IsValid)
            {
                _basicProfileService.Create(_mapper.Map<BasicProfile>(basicProfile));
                return RedirectToAction("Index");
            }

            return View("Create", basicProfile);
        }

        public IActionResult View(int id)
        {
            var basicProfile = _basicProfileService.GetById(id);

            if (basicProfile == null) return NotFound();

            return View(_mapper.Map<BasicProfileViewModel>(basicProfile));
        }

        public IActionResult Edit(int id)
        {
            var basicProfile = _basicProfileService.GetById(id);

            if (basicProfile == null) return NotFound();

            return View(_mapper.Map<BasicProfileViewModel>(basicProfile));
        }

        [HttpPost]
        public IActionResult Update(BasicProfileViewModel basicProfile)
        {

            if (ModelState.IsValid)
            {
                _basicProfileService.Update(_mapper.Map<BasicProfile>(basicProfile));

                return RedirectToAction("View", new { id = basicProfile.Id });
            }

            return View("Edit", basicProfile);
        }
    }
}
