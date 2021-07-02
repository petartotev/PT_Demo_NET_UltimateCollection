using CarDemo.Web.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDemo.Web.Models.Engines
{
    public class EngineViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public int NumberCylinders { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public CarViewModel Car { get; set; }
    }
}
