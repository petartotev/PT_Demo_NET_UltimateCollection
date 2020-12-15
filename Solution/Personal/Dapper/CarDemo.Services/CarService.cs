﻿using AutoMapper;
using CarDemo.Data.Models;
using CarDemo.Services.Contracts;
using CarDemo.Services.Models.Car;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CarDemo.Services
{
    public class CarService : ICarService
    {
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public CarService(IConfiguration config, IMapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }

        public IEnumerable<CarServiceModel> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnection"].ConnectionString))
            //using (IDbConnection db = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=CarDemo;Integrated Security=True;"))
            using (IDbConnection db = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                cars = db.Query<Car>("Select * From Cars").ToList();
            }

            var result = this.mapper.Map<IEnumerable<CarServiceModel>>(cars);
            return result;
        }

        public CarServiceModel GetCarById(Guid id)
        {
            Car car = new Car();

            using (IDbConnection db = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                car = db.Query<Car>($"Select * From Cars Where Id = '{id}'").SingleOrDefault();
            }

            var result = this.mapper.Map<CarServiceModel>(car);
            return result;
        }
    }
}
