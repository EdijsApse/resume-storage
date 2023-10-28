using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}
