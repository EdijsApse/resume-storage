using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResumeStorage.Core.Models;
using ResumeStorage.Core.Services;
using ResumeStorage.Models;

namespace ResumeStorage.Controllers
{
    public class BasicProfileController : BaseController
    {
        private readonly IBasicProfileService _basicProfileService;

        public BasicProfileController(IBasicProfileService basicProfileService, IMapper mapper) : base(mapper)
        {
            _basicProfileService = basicProfileService;
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
                
                TempData["success"] = "Basic Profile details created!";

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

                TempData["success"] = "Basic Profile details updated!";

                return Redirect($"/Resume/View/{basicProfile.Id}");
            }

            return View("Edit", basicProfile);
        }
    }
}
