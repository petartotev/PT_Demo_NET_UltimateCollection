using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDemo.Data.Configuration
{
    public class DoorConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> doors)
        {
            doors
                .HasOne(door => door.Car)
                .WithMany(cr => cr.Doors)
                .HasForeignKey(door => door.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            doors
                .HasOne(door => door.Handle)
                .WithOne(hndl => hndl.Door)
                .HasForeignKey<Handle>(hndl => hndl.DoorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
