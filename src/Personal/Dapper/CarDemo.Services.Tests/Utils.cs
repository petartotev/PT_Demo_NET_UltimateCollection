using AutoMapper;
using CarDemo.Data;
using CarDemo.Data.Models;
using CarDemo.Services.Models.Car;
using CarDemo.Services.Models.Engine;
using CarDemo.Web.Models.Cars;
using CarDemo.Web.Models.Engines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarDemo.Services.Tests
{
    public class Utils
    {
        private static MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
        {
            // Data Models -> Service Models

            cfg.CreateMap<Car, CarServiceModel>()
                .ForMember(dest => dest.CountDoors, opt => opt.MapFrom(src => src.Doors.Count()))
                .ForMember(dest => dest.CountDrivers, opt => opt.MapFrom(src => src.Drivers.Count()));

            cfg.CreateMap<Engine, EngineServiceModel>();

            // Service Models <-> View Models

            cfg.CreateMap<CarServiceModel, CarViewModel>().ReverseMap();

            cfg.CreateMap<EngineServiceModel, EngineViewModel>().ReverseMap();
        });

        private Random random = new Random();

        private static IMapper mapper;

        public static DbContextOptions<CarDemoDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<CarDemoDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        private static IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    mapper = new Mapper(mapperConfig);
                }

                return mapper;
            }
        }

        public static User CreateMockUser(string firstName, string lastName)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                IsDeleted = false,
                IsAdmin = false,
                IsBanned = false,
                UserName = $"{firstName.ToLower()}{lastName.ToLower()}@mail.com",
                Email = $"{firstName.ToLower()}{lastName.ToLower()}@mail.com",
                NormalizedUserName = $"{firstName.ToUpper()}{lastName.ToUpper()}@MAIL.COM",
                NormalizedEmail = $"{firstName.ToUpper()}{lastName.ToUpper()}@MAIL.COM",
            };
        }

        public static Car CreateMockCar(string brand, string model)
        {
            return new Car
            {
                Id = Guid.NewGuid(),
                Brand = brand,
                Model = model,
                Color = "black",
                DateProduction = DateTime.UtcNow,
                Image = $"/images/cars/car_1.jpg",
                IsAutomatic = true,
                Price = 19999.99,
            };
        }

        public static Engine CreateMockEngine(string name, Guid carId)
        {
            return new Engine
            {
                Id = Guid.NewGuid(),
                Name = name,
                CarId = carId,
                DateProduction = DateTime.UtcNow,
                Image = $"/images/engines/engine_1.jpg",
                NumberCylinders = 6,
                Price = 4999.99,
                Volume = 1.6,
            };
        }
    }
}
