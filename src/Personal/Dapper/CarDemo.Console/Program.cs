using CarDemo.Data;
using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDemo.Console
{
    public class Program
    {
        private static readonly List<string> listFirstNames = new List<string>()
            {
                "James",
                "Michael",
                "Robert",
                "John",
                "David",
                "William",
                "Richard",
                "Thomas",
                "Mark",
                "Charles", // 10
                "Steven",
                "Gary",
                "Joseph",
                "Donald",
                "Ronald",
                "Kenneth",
                "Paul",
                "Larry",
                "Daniel",
                "Stephen", // 20
                "Dennis",
                "Timothy",
                "Edward",
                "Jeffrey",
                "George",
                "Gregory",
                "Kevin",
                "Douglas",
                "Terry",
                "Anthony", // 30
                "Jerry",
                "Bruce",
                "Randy",
                "Brian",
                "Frank",
                "Scott",
                "Roger",
                "Raymond",
                "Peter",
                "Patrick", // 40
                "Keith",
                "Lawrence",
                "Wayne",
                "Danny",
                "Alan",
                "Gerald",
                "Ricky",
                "Carl",
                "Christopher",
                "Dale", // 50
                "Mary",
                "Linda",
                "Patricia",
                "Susan",
                "Deborah",
                "Barbara",
                "Debra",
                "Karen",
                "Nancy",
                "Donna", // 10
                "Cynthia",
                "Sandra",
                "Pamela",
                "Sharon",
                "Kathleen",
                "Carol",
                "Diane",
                "Brenda",
                "Cheryl",
                "Janet", // 20
                "Elizabeth",
                "Kathy",
                "Margaret",
                "Janice",
                "Carolyn",
                "Denise",
                "Judy",
                "Rebecca",
                "Joyce",
                "Teresa", // 30
                "Christine",
                "Catherine",
                "Shirley",
                "Judith",
                "Betty",
                "Beverly",
                "Lisa",
                "Laura",
                "Theresa",
                "Connie", // 40
                "Ann",
                "Gloria",
                "Julie",
                "Gail",
                "Joan",
                "Paula",
                "Peggy",
                "Cindy",
                "Martha",
                "Bonnie", // 50
            };

        private static readonly List<string> listLastNames = new List<string>()
            {
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Jones",
                "Garcia",
                "Miller",
                "Davis",
                "Rodriguez",
                "Martinez", // 10
                "Hernandez",
                "Lopez",
                "Gonzalez",
                "Wilson",
                "Anderson",
                "Taylor",
                "Thomas",
                "Moore",
                "Jackson",
                "Martin", // 20
                "Lee",
                "Perez",
                "Thompson",
                "White",
                "Harris",
                "Sanchez",
                "Clark",
                "Ramirez",
                "Lewis",
                "Robinson", // 30
                "Walker",
                "Young",
                "Allen",
                "King",
                "Wright",
                "Scott",
                "Torres",
                "Nguyen",
                "Hill",
                "Flores", // 40
                "Green",
                "Adams",
                "Nelson",
                "Baker",
                "Hall",
                "Rivera",
                "Campbell",
                "Mitchell",
                "Carter",
                "Roberts", // 50
            };

        private static readonly List<string> listOccupations = new List<string>()
        {
            "Architect",
            "IT",
            "Lawyer",
            "Doctor",
            "Engineer",
            "Teacher",
            "Minister",
            "Driver",
            "Other"
        };

        private static readonly List<string> listBrands = new List<string>()
        {
            "Mercedes",
            "BMW",
            "Volvo",
            "Peugeot",
            "Renault",
            "Lada",
            "Opel",
            "Volkswagen",
        };

        private static readonly List<string> listModels = new List<string>()
        {
            "Toureg",
            "Passat",
            "Vectra",
            "Astra",
            "Megane",
            "Clio",
            "X5"
        };

        private static readonly List<string> listColors = new List<string>()
        {
            "Blue",
            "Red",
            "Yellow",
            "Black",
            "White",
            "Grey"
        };

        public static void Main()
        {
            Random rndm = new Random();

            using var db = new CarDemoDbContext(new DbContextOptionsBuilder<CarDemoDbContext>()
            .UseSqlServer("Server=localhost;Database=CarDemo;Integrated Security=True;")
            .Options);

            // Drivers
            for (int i = 0; i < 25; i++)
            {
                db.Drivers.Add(new Driver
                {
                    FirstName = listFirstNames[rndm.Next(0, listFirstNames.Count)],
                    LastName = listLastNames[rndm.Next(0, listLastNames.Count)],
                    Image = $"/images/drivers/driver_{rndm.Next(1, 4)}.jpg",
                    Occupation = listOccupations[rndm.Next(0, listOccupations.Count)],
                });
                db.SaveChanges();
            }

            // Cars
            for (int i = 0; i < 25; i++)
            {
                db.Cars.Add(new Car
                {
                    Brand = listBrands[rndm.Next(0, listBrands.Count)],
                    Model = listModels[rndm.Next(0, listModels.Count)],
                    IsAutomatic = false,
                    Color = listColors[rndm.Next(0, listColors.Count)],
                    DateProduction = DateTime.UtcNow.AddYears(rndm.Next(-10, 0)).AddMonths(rndm.Next(-12, 0)).AddDays(rndm.Next(-365, 0)),
                    Image = $"/images/cars/car_{rndm.Next(1, 4)}.jpg",
                    Price = rndm.Next(10000, 100000) + 0.99,
                });
                db.SaveChanges();
            }

            // Engines
            for (int i = 0; i < 25; i++)
            {
                db.Engines.Add(new Engine
                {
                    DateProduction = DateTime.UtcNow.AddYears(rndm.Next(-10, 0)).AddMonths(rndm.Next(-12, 0)).AddDays(rndm.Next(-365, 0)),
                    Image = $"/images/engines/engine_{rndm.Next(1, 4)}.jpg",
                    Price = rndm.Next(5000, 250000) + 0.99,
                    Name = $"Engine {i}",
                    NumberCylinders = rndm.Next(4, 13),
                    Volume = rndm.Next(10, 40) * 0.1,
                    CarId = db.Cars.Skip(i).First().Id,
                });
                db.SaveChanges();
            }

            // Drivers <-> Cars
            for (int i = 0; i < 10; i++)
            {
                db.CarDrivers.Add(new CarDriver
                {
                    CarId = db.Cars.Skip(i).First().Id,
                    DriverId = db.Drivers.Skip(i).First().Id,
                });
                db.SaveChanges();
            }
        }
    }
}
