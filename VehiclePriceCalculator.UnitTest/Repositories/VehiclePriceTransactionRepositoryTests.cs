using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Infrastructure.Data;
using VehiclePriceCalculator.Infrastructure.Repository;
using Xunit;

namespace VehiclePriceCalculator.UnitTests.Repositories
{
    public class VehiclePriceTransactionRepositoryTests
    {
        [Fact]
        public async Task GetVehiclePriceTransactionListAsync_Should_Return_VehiclePriceTransactions()
        {
            // Arrange
            var data = new List<VehiclePriceTransaction>
            {
                new VehiclePriceTransaction {
                Id = 1,
                VehiclePrice = 398M,
                BasicFee = 39.80M,
                SpecialFee = 7.96M,
                AssociationFee = 5.00M,
                StorageFee = 100,
                TotalCost = 550.76M
                }
            };

            var dbContextOptions = new DbContextOptionsBuilder<VehiclePriceCalculatorDbContext>()
                .UseInMemoryDatabase(databaseName: "Progi")
                .Options; //create in-memory database context for VehiclePriceCalculatorDbContext using DbContextOptionsBuilder

            using (var dbContext = new VehiclePriceCalculatorDbContext(dbContextOptions))
            {
                await dbContext.AddRangeAsync(data); //adds mock data to the in-memory database context asynchronously. AddRangeAsync method adds a collection of entities to the context but does not immediately save changest to the database
                await dbContext.SaveChangesAsync(); // save changes made to the database context asynchronously. Ensures mock data is aactually stored in the in-memory database before proceeding with the test
            }

            using (var dbContext = new VehiclePriceCalculatorDbContext(dbContextOptions))
            {
                var repository = new VehiclePriceTransactionRepository(dbContext, Mock.Of<IAppLogger<VehiclePriceTransaction>>());

                // Act
                var result = await repository.GetVehiclePriceTransactionListAsync();

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.IsAssignableFrom<IEnumerable<VehiclePriceTransaction>>(result);
                
   
            }
        }

        [Fact]
        public async Task AddVehiclePriceTransactionListAsync_Should_Add_VehiclePriceTransaction()
        {
            // Arrange
            var vehiclePriceTransaction = new VehiclePriceTransaction
            {
                Id = 1,
                VehiclePrice = 398M,
                BasicFee = 39.80M,
                SpecialFee = 7.96M,
                AssociationFee = 5.00M,
                StorageFee = 100,
                TotalCost = 550.76M
            };

            var dbContextOptions = new DbContextOptionsBuilder<VehiclePriceCalculatorDbContext>()
                .UseInMemoryDatabase(databaseName: "Progi")
                .Options;

            using (var dbContext = new VehiclePriceCalculatorDbContext(dbContextOptions))
            {
                var repository = new VehiclePriceTransactionRepository(dbContext, Mock.Of<IAppLogger<VehiclePriceTransaction>>());

                // Act
                var result = repository.AddVehiclePriceTransactionListAsync(vehiclePriceTransaction);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(vehiclePriceTransaction.Id, result.Id);
            }
        }
    }
}
