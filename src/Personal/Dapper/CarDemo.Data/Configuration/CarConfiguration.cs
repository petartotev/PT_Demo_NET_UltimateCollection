using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDemo.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> cars)
        {
            cars
                .HasOne(car => car.Engine)
                .WithOne(eng => eng.Car)
                .HasForeignKey<Engine>(eng => eng.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            cars
                .HasMany(car => car.Doors)
                .WithOne(dr => dr.Car)
                .HasForeignKey(dr => dr.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
