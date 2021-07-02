using System;
using System.Collections.Generic;

namespace CarDemo.Data.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public bool IsAutomatic { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public ICollection<Door> Doors { get; set; } = new HashSet<Door>();

        public ICollection<CarDriver> Drivers { get; set; } = new HashSet<CarDriver>();

        public Engine Engine { get; set; }
    }
}
