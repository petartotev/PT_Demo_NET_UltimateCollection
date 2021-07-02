using AutoMapper;
using CarDemo.Data;
using CarDemo.Data.Models;
using CarDemo.Services.Models.Car;
using Xunit;

namespace CarDemo.Services.Tests.CarServiceTests
{
    public class GetAllCars_Should
    {
        [Fact]
        public void ReturnCorrectCollectionCarsServiceModels_When_DatabaseContainsCars()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectCollectionCarsServiceModels_When_DatabaseContainsCars));
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Car, CarServiceModel>().ReverseMap(); });
            var mapper = new Mapper(config);

            User user1 = Utils.CreateMockUser("user1FirstName", "user1LastName");
            Car car1 = Utils.CreateMockCar("BMW", "X5");
            Car car2 = Utils.CreateMockCar("Mercedes", "Benz");
            Engine engine1 = Utils.CreateMockEngine("Super Turbo", car1.Id);
            Engine engine2 = Utils.CreateMockEngine("Super Turbo 2", car2.Id);

            using (var arrangeContext = new CarDemoDbContext(options))
            {
                arrangeContext.Cars.Add(car1);
                arrangeContext.Cars.Add(car2);
                arrangeContext.Engines.Add(engine1);
                arrangeContext.Engines.Add(engine2);
                arrangeContext.SaveChanges();
            }

            using (var actContext = new CarDemoDbContext(options))
            {
                //CarService sut = new CarService(actContext, mapper);
                //var result = sut.GetAllCars();
                //Assert.Equal(2, result.Count());
            }
        }
    }
}
