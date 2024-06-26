﻿using CarDemo.Web.Models.Engines;
using System;

namespace CarDemo.Web.Models.Cars
{
    public class CarViewModel
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public bool IsAutomatic { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public int CountDoors { get; set; }

        public int CountDrivers { get; set; }

        public EngineViewModel Engine { get; set; }
    }
}
