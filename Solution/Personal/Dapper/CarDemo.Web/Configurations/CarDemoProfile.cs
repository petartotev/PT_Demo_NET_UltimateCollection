using AutoMapper;
using CarDemo.Data.Models;
using CarDemo.Services.Models.Car;
using CarDemo.Services.Models.Engine;
using CarDemo.Web.Models.Cars;
using CarDemo.Web.Models.Engines;
using System.Linq;

namespace CarDemo.Web.Configurations
{
    public class CarDemoProfile : Profile
    {
        public CarDemoProfile()
        {
            // Data Models -> Service Models

            CreateMap<Car, CarServiceModel>()
                .ForMember(dest => dest.CountDoors, opt => opt.MapFrom(src => src.Doors.Count()))
                .ForMember(dest => dest.CountDrivers, opt => opt.MapFrom(src => src.Drivers.Count()));

            CreateMap<Car, CarViewModel>();

            CreateMap<Engine, EngineServiceModel>();

            // Service Models <-> View Models

            CreateMap<CarServiceModel, CarViewModel>().ReverseMap();

            CreateMap<EngineServiceModel, EngineViewModel>().ReverseMap();
        }
    }
}
