using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Repository;
using Xunit;

namespace VehiclePriceCalculator.UnitTests.Repositories
{
    public class VehicleTypeRepositoryTests
    {
        [Fact]
        public async Task GetVehicleTypeListAsync_Should_Return_All_Vehicle_Types()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VehiclePriceCalculatorDbContext>()
                .UseInMemoryDatabase(databaseName: "Progi")
                .Options;

            using (var context = new VehiclePriceCalculatorDbContext(options))
            {
                var repository = new VehicleTypeRepository(context, Mock.Of<IAppLogger<VehicleType>>());

                // Add some test data to the in-memory database
                var vehicleTypeList = new List<VehicleType>
                {
                    new VehicleType { Id = 1, VehicleTypeName = "Common" },
                    new VehicleType { Id = 2, VehicleTypeName = "Luxury" },
                };

                await context.VehicleType.AddRangeAsync(vehicleTypeList);
                await context.SaveChangesAsync();

                // Act
                var result = await repository.GetVehicleTypeListAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(vehicleTypeList.Count, result.Count());
            }
        }

        // Additional tests can be written for other repository methods
    }
}
