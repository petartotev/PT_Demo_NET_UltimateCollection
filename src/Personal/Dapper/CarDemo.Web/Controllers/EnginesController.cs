using AutoMapper;
using CarDemo.Services.Contracts;
using CarDemo.Services.Models.Engine;
using CarDemo.Web.Models.Engines;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarDemo.Web.Controllers
{
    public class EnginesController : Controller
    {
        private readonly IEngineService engineService;
        private readonly IMapper mapper;
        public EnginesController(IEngineService engineService, IMapper mapper)
        {
            this.engineService = engineService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            IEnumerable<EngineServiceModel> engines = engineService.GetAllEngines();

            IEnumerable<EngineViewModel> models = this.mapper.Map<IEnumerable<EngineViewModel>>(engines);

            return this.View(models);
        }

        public IActionResult Engine(Guid id)
        {
            EngineServiceModel engine = engineService.GetEngineById(id);

            EngineViewModel model = this.mapper.Map<EngineViewModel>(engine);

            return this.View(model);
        }
    }
}
