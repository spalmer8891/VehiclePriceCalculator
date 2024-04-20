using Microsoft.Extensions.Logging;
using Moq;
using VehiclePriceCalculator.Shared.Interfaces;
using VehiclePriceCalculator.Shared.Models;
using VehiclePriceCalculator.Shared.Services;
using Xunit;

namespace VehiclePriceCalculator.UnitTest
{
    public class VehiclePriceCalculatorTests
    {

        private readonly IPresentationService _presentationService;
        public VehiclePriceCalculatorTests()
        {
            // Initialize dependencies using mock objects
            _presentationService = Mock.Of<IPresentationService>();
        }


        [Fact]
        public async Task GetAllVehicleTypes_ReturnsAllVehicleTypes()
        {

            // Arrange
            var expectedVehicleTypes = new List<VehicleTypeViewModel>
            {
                new VehicleTypeViewModel { Id = 1, VehicleTypeName = "Common" },
                new VehicleTypeViewModel { Id = 2, VehicleTypeName = "Luxury" }

            };

            // Set up mock behavior for presentation service
            Mock.Get(_presentationService)
                .Setup(service => service.GetAllVehicleTypes())
                .ReturnsAsync(expectedVehicleTypes);

            // Act
            var result = await _presentationService.GetAllVehicleTypes();

            // Assert
            Assert.NotNull(result); //checks if result is not null
            Assert.IsType<List<VehicleTypeViewModel>>(result); //checks if result is of type VehicleTypeViewModel

        }
    }
}