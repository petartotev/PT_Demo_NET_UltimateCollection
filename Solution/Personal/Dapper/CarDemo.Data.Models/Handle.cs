using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemo.Data.Models
{
    public class Handle
    {
        public Guid Id { get; set; }

        public string Material { get; set; }

        public bool IsAutomatic { get; set; }

        public double Price { get; set; }

        public DateTime DateProduction { get; set; }

        public string Image { get; set; }

        public Guid DoorId { get; set; }
        public Door Door { get; set; }
    }
}
