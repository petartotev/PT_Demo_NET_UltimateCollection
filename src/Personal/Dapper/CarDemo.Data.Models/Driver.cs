using System;
using System.Collections.Generic;

namespace CarDemo.Data.Models
{
    public class Driver
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Occupation { get; set; }

        public string Image { get; set; }

        public ICollection<CarDriver> Cars { get; set; } = new HashSet<CarDriver>();
    }
}
