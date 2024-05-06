using MediatR;
using Moq;
using VehiclePriceCalculator.Application.CQRS.Queries;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Application.Services;
using VehiclePriceCalculator.Domain.Interfaces;

namespace VehiclePriceCalculator.UnitTests.Services
{
    public class VehicleTypeServiceTests
    {
        [Fact]
        public async Task GetVehicleTypeNameList_Should_Return_VehicleTypeModels()
        {
            // Arrange

            var vehicleTypeList = new List<VehicleTypeModel>
            {
                new VehicleTypeModel { Id = 1, VehicleTypeName = "Common" },
                new VehicleTypeModel { Id = 2, VehicleTypeName = "Luxury" },
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetAllVehicleTypesQuery>(), default))
                        .ReturnsAsync(vehicleTypeList);

            var loggerMock = new Mock<IAppLogger<VehicleTypeService>>();

            var vehicleTypeService = new VehicleTypeService(mediatorMock.Object, loggerMock.Object);

            // Act
            var result = await vehicleTypeService.GetVehicleTypeNameList();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<VehicleTypeModel>>(result);
            Assert.Equal(vehicleTypeList, result); // Check if the returned data matches the expected data
        }
    }
}
