﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ResumeStorage.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
