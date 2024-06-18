using AutoMapper;
using CarDemo.Services.Contracts;
using CarDemo.Services.Models.Car;
using CarDemo.Web.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarDemo.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IMapper mapper;
        public CarsController(ICarService carService, IMapper mapper)
        {
            this.carService = carService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            IEnumerable<CarServiceModel> cars = carService.GetAllCars();

            IEnumerable<CarViewModel> models = this.mapper.Map<IEnumerable<CarViewModel>>(cars);

            return this.View(models);
        }

        public IActionResult Car(Guid id)
        {
            CarServiceModel car = carService.GetCarById(id);

            CarViewModel model = this.mapper.Map<CarViewModel>(car);

            return this.View(model);
        }
    }
}
