using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehiclePriceCalculator.Shared.Interfaces;
using VehiclePriceCalculator.Shared.Services;

namespace VehiclePriceCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclePriceCalculatorController : ControllerBase
    {
        private readonly IPresentationService _presentationService;
        private readonly ILogger<VehiclePriceCalculatorController> _logger;

        public VehiclePriceCalculatorController(IPresentationService presentationService, ILogger<VehiclePriceCalculatorController> logger)
        {
            _presentationService = presentationService ?? throw new ArgumentNullException(nameof(presentationService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("vehicleTypes")]
        public async Task<IActionResult> GetAllVehicleTypes()
        {
            var vehicleTypeList = await _presentationService.GetAllVehicleTypes();
            return Ok(vehicleTypeList);
        }

        [HttpGet("vehiclePriceTransaction")]
        public async Task<IActionResult> GetAllVehiclePriceTransactions()
        {
            var vehiclePriceTransactionList = await _presentationService.GetAllVehiclePriceTransactions();
            return Ok(vehiclePriceTransactionList);
        }

        [HttpPost("addVehiclePriceTransaction")]
        public async Task<IActionResult> AddVehiclePriceTransactions([FromBody] decimal basePrice, string vehicleType)
        {
            var vehicleTypeList = await _presentationService.AddVehiclePriceTransactions(basePrice,vehicleType);
            return Ok(vehicleTypeList);
        }
    }
}
