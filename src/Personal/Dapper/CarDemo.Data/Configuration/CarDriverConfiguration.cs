using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDemo.Data.Configuration
{
    public class CarDriverConfiguration : IEntityTypeConfiguration<CarDriver>
    {
        public void Configure(EntityTypeBuilder<CarDriver> carDriver)
        {
            carDriver
                .HasKey(cd => new { cd.CarId, cd.DriverId });

            carDriver
                .HasOne(cd => cd.Car)
                .WithMany(car => car.Drivers)
                .HasForeignKey(cd => cd.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            carDriver
                .HasOne(cd => cd.Driver)
                .WithMany(dr => dr.Cars)
                .HasForeignKey(cd => cd.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
