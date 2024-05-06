using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Infrastructure.Repository;
using Xunit;

namespace VehiclePriceCalculator.UnitTests.Repositories
{
    public class GenericRepositoryTests
    {
        [Fact]
        public async Task GetAllAsync_Should_Return_All_Entities()
        {
            // Arrange
            var dbContextMock = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<VehiclePriceTransaction>>();
            var loggerMock = new Mock<IAppLogger<VehiclePriceTransaction>>();

            dbContextMock.Setup(x => x.Set<VehiclePriceTransaction>()).Returns(dbSetMock.Object);

            var repository = new GenericRepository<VehiclePriceTransaction>(dbContextMock.Object, loggerMock.Object);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
           
        }

        [Fact]
        public async Task AddAsync_Should_Add_Entity()
        {
            // Arrange
            var dbContextMock = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<VehiclePriceTransaction>>();
            var loggerMock = new Mock<IAppLogger<VehiclePriceTransaction>>();

            var entity = new VehiclePriceTransaction { Id = 1 };

            var repository = new GenericRepository<VehiclePriceTransaction>(dbContextMock.Object, loggerMock.Object);

            // Act
            var result = repository.AddAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
        }

    }
}
