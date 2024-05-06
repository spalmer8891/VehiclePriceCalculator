using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using VehiclePriceCalculator.WebApp.Pages;
using VehiclePriceCalculator.Shared.Interfaces;
using VehiclePriceCalculator.Shared.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using VehiclePriceCalculator.Domain.Model;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Services;

namespace VehiclePriceCalculator.UnitTests.Pages
{
    public class IndexModelTests
    {
        [Fact]
        public async Task OnGet_Success()
        {
            // Arrange
            var presentationServiceMock = new Mock<IPresentationService>();

            var vehicleTypeList = new List<VehicleTypeViewModel>
            {
                new VehicleTypeViewModel { Id = 1, VehicleTypeName = "Common" },
                new VehicleTypeViewModel { Id = 2, VehicleTypeName = "Luxury" },
            };

            presentationServiceMock.Setup(x => x.GetAllVehicleTypes()).ReturnsAsync(vehicleTypeList);

            var vehiclePriceTransactionList = new List<VehiclePriceTransactionViewModel>
            {
                new VehiclePriceTransactionViewModel
                {
                    Id = 1,
                    VehiclePrice = 398M,
                    BasicFee = 39.80M,
                    SpecialFee = 7.96M,
                    AssociationFee = 5.00M,
                    StorageFee = 100,
                    TotalCost = 550.76M

                }
            };

            presentationServiceMock.Setup(x => x.GetAllVehiclePriceTransactions()).ReturnsAsync(vehiclePriceTransactionList);

            var loggerMock = new Mock<ILogger<IndexModel>>();
            var indexModel = new IndexModel(presentationServiceMock.Object, loggerMock.Object);

            // Act
            await indexModel.OnGet();

            // Assert
            Assert.NotNull(indexModel.VehicleTypeList);
            Assert.NotEmpty(indexModel.VehicleTypeList);
            Assert.NotNull(indexModel.VehiclePriceTransactionList);
            Assert.NotEmpty(indexModel.VehiclePriceTransactionList);
            Assert.IsType<List<VehiclePriceTransactionViewModel>>(indexModel.VehiclePriceTransactionList);
        }

        [Fact]
        public async Task OnPost_Success()
        {
            // Arrange
            var presentationServiceMock = new Mock<IPresentationService>();

            var vehiclePriceTransactionList = new List<VehiclePriceTransactionViewModel>
            {
                new VehiclePriceTransactionViewModel
                {
                    Id = 1,
                    VehiclePrice = 398M,
                    BasicFee = 39.80M,
                    SpecialFee = 7.96M,
                    AssociationFee = 5.00M,
                    StorageFee = 100,
                    TotalCost = 550.76M

                }
            };

            presentationServiceMock.Setup(x => x.AddVehiclePriceTransactions(It.IsAny<VehicleCalculateModel>())).ReturnsAsync(new VehiclePriceTransactionViewModel());
            presentationServiceMock.Setup(x => x.GetAllVehiclePriceTransactions()).ReturnsAsync(vehiclePriceTransactionList);


            var vehicleTypeList = new List<VehicleTypeViewModel>
            {
                new VehicleTypeViewModel { Id = 1, VehicleTypeName = "Common" },
                new VehicleTypeViewModel { Id = 2, VehicleTypeName = "Luxury" },
            };

            presentationServiceMock.Setup(x => x.GetAllVehicleTypes()).ReturnsAsync(vehicleTypeList);

            var loggerMock = new Mock<ILogger<IndexModel>>();
            var indexModel = new IndexModel(presentationServiceMock.Object, loggerMock.Object);
            indexModel.BasePrice = 100; // Set base price to simulate form submission

            // Act
            await indexModel.OnPost();

            // Assert
            Assert.Equal(0, indexModel.BasePrice);
            Assert.NotNull(indexModel.VehicleTypeList);
            Assert.NotEmpty(indexModel.VehicleTypeList);
            Assert.NotNull(indexModel.VehiclePriceTransactionList);
            Assert.NotEmpty(indexModel.VehiclePriceTransactionList);
            Assert.IsType<List<VehiclePriceTransactionViewModel>>(indexModel.VehiclePriceTransactionList);
        }
    }
}
