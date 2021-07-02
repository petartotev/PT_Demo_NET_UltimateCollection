using System;

namespace CarDemo.Data.Models
{
    public class Engine
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public int NumberCylinders { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
