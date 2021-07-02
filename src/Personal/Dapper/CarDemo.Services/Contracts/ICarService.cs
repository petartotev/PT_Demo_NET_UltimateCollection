using CarDemo.Services.Models.Car;
using System;
using System.Collections.Generic;

namespace CarDemo.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarServiceModel> GetAllCars();

        CarServiceModel GetCarById(Guid id);
    }
}
