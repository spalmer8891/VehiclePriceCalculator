using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Infrastructure.Data
{
    public class VehiclePriceCalculatorDbContext:DbContext
    {

        public VehiclePriceCalculatorDbContext(DbContextOptions<VehiclePriceCalculatorDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehiclePriceTransaction> VehiclePriceTransaction { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehiclePriceTransaction>(entity =>
            {
                // Define an index on the VehicleTypeId column and set its unique constraint to false
                entity.HasIndex(e => e.VehicleTypeId).IsUnique(false);
            });

            // Seed data for VehicleType table
            modelBuilder.Entity<VehicleType>().HasData(
               new VehicleType { Id = 1, VehicleTypeName = "Common", DateCreated = DateTime.Now, DateModified = DateTime.Now,CreatedBy="System", ModifiedBy="System"},
               new VehicleType { Id = 2, VehicleTypeName = "Luxury", DateCreated = DateTime.Now, DateModified = DateTime.Now,CreatedBy="System",ModifiedBy="System" }
           );
        }

    }

}
