using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDemo.Data.Configuration
{
    public class HandleConfiguration : IEntityTypeConfiguration<Handle>
    {
        public void Configure(EntityTypeBuilder<Handle> handles)
        {
            handles
                .HasOne(hndl => hndl.Door)
                .WithOne(dr => dr.Handle)
                .HasForeignKey<Handle>(hndl => hndl.DoorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
