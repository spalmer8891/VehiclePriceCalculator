using AutoMapper;
using MediatR;
using Moq;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Application.Services;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;
using VehiclePriceCalculator.Domain.Model;


namespace VehiclePriceCalculator.UnitTests.Services
{
    public class VehiclePriceTransactionServiceTests
    {
        [Fact]
        public async Task GetVehiclePriceTransactionList_Should_Return_Mapped_List()
        {
            // Arrange
            var vehiclePriceTransactionList = new List<VehiclePriceTransaction>
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

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<IEnumerable<VehiclePriceTransactionModel>>(It.IsAny<IEnumerable<VehiclePriceTransaction>>()))
                .Returns(new List<VehiclePriceTransactionModel>());

            var repositoryMock = new Mock<IVehiclePriceTransactionRepository>();
            repositoryMock.Setup(r => r.GetVehiclePriceTransactionListAsync()).ReturnsAsync(vehiclePriceTransactionList);

            var mediatorMock = new Mock<IMediator>();
            var calculateServiceMock = new Mock<IVehiclePriceCalculate>();

            var service = new VehiclePriceTransactionService(repositoryMock.Object, calculateServiceMock.Object, mapperMock.Object, mediatorMock.Object);

            // Act
            var result = await service.GetVehiclePriceTransactionList();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<VehiclePriceTransactionModel>>(result); //check if result is assinable to variable of type IEnumerable<VehiclePriceTransactionModel>

        }

        [Fact]
        public async Task CalculateVehiclePrice_Should_Return_Correct_Result()
        {
            // Arrange
            var calculateModel = new VehicleCalculateModel
            {
                BasePrice = 398M,
                VehicleType = (Domain.Enum.VehicleType)1,
                StorageFee = 100
            };

            var expectedModel = new VehiclePriceTransactionModel
            {
                Id = 1,
                VehiclePrice = 398M,
                BasicFee = 39.80M,
                SpecialFee = 7.96M,
                AssociationFee = 5.00M,
                StorageFee = 100,
                TotalCost = 550.76M
            };

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


            var calculateServiceMock = new Mock<IVehiclePriceCalculate>();
            calculateServiceMock.Setup(c => c.CalculateTotalCost(It.IsAny<VehicleCalculateModel>())).Returns(vehiclePriceTransaction);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<VehiclePriceTransactionModel>(It.IsAny<VehiclePriceTransaction>()))
                .Returns(expectedModel);

            var mediatorMock = new Mock<IMediator>();
            var repositoryMock = new Mock<IVehiclePriceTransactionRepository>();

            var service = new VehiclePriceTransactionService(repositoryMock.Object, calculateServiceMock.Object, mapperMock.Object, mediatorMock.Object);

            // Act
            var result = await service.CalculateVehiclePrice(calculateModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedModel, result);
            //Assert.Equal(expectedModel.Id, result.Id); // Add assertions for each property
            //Assert.Equal(expectedModel.BasicFee, result.BasicFee); // Add assertions for each property

        }
    }
}

