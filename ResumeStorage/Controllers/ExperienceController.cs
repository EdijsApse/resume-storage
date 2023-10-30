﻿using AutoMapper;
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

                return Redirect($"/Resume/View/{basicProfileId}");
            }

            return View("Create", new ExperienceListViewModel { ListOfExperiences = listOfExperiences, ResumeId = basicProfileId });
        }
    }
}
