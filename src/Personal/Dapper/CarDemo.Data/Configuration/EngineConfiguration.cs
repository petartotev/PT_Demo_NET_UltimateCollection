using CarDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemo.Data.Configuration
{
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> engines)
        {
            engines
                .HasOne(engn => engn.Car)
                .WithOne(cr => cr.Engine)
                .HasForeignKey<Engine>(eng => eng.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
