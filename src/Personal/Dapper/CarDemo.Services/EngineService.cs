using CarDemo.Data;
using CarDemo.Data.Models;
using CarDemo.Services.Contracts;
using CarDemo.Services.Models.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDemo.Services
{
    public class EngineService : IEngineService
    {
        private readonly CarDemoDbContext db;

        public EngineService(CarDemoDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<EngineServiceModel> GetAllEngines()
        {
            return this.db.Engines
                .Select(x => new EngineServiceModel
                {
                    Id = x.Id,
                    DateProduction = x.DateProduction,
                    Price = x.Price,
                    Image = x.Image,
                    Name = x.Name,
                    NumberCylinders = x.NumberCylinders,
                    Volume = x.Volume,
                });
        }

        public EngineServiceModel GetEngineById(Guid id)
        {
            Engine x = this.db.Engines.First(y => y.Id == id);

            return new EngineServiceModel
            {
                Id = x.Id,
                DateProduction = x.DateProduction,
                Price = x.Price,
                Image = x.Image,
                Name = x.Name,
                NumberCylinders = x.NumberCylinders,
                Volume = x.Volume,
            };
        }
    }
}
