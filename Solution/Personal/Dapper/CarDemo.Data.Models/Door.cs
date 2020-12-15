using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemo.Data.Models
{
    public class Door
    {
        public Guid Id { get; set; }

        public bool IsOpenable { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public Handle Handle { get; set; }
    }
}
