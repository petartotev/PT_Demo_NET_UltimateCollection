using CarDemo.Services.Models.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemo.Services.Models.Engine
{
    public class EngineServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public int NumberCylinders { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public CarServiceModel Car { get; set; }
    }
}
