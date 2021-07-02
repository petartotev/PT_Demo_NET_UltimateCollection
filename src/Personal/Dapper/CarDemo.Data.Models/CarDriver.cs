using System;

namespace CarDemo.Data.Models
{
    public class CarDriver
    {
        public Guid CarId { get; set; }

        public Car Car { get; set; }

        public Guid DriverId { get; set; }

        public Driver Driver { get; set; }
    }
}
