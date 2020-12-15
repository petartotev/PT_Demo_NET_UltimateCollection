using CarDemo.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarDemo.Data
{
    public class CarDemoDbContext : IdentityDbContext<User, Role, Guid>
    {
        public CarDemoDbContext(DbContextOptions<CarDemoDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarDriver> CarDrivers { get; set; }

        public DbSet<Door> Doors { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Handle> Handles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=PT\\SQLEXPRESS;Database=CarDemo;Integrated Security=True;");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
        }
    }
}
