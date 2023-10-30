using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
                return Redirect("/Resume/Index");
            }

            return View("Create", basicProfile);
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

                return Redirect($"/Resume/View/{basicProfile.Id}");
            }

            return View("Edit", basicProfile);
        }
    }
}
