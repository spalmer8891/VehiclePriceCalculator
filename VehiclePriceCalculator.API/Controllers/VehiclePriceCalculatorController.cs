using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehiclePriceCalculator.API.Interfaces;
using VehiclePriceCalculator.API.Services;

namespace VehiclePriceCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclePriceCalculatorController : ControllerBase
    {
        private readonly IAPIService _APIService;
        private readonly ILogger<VehiclePriceCalculatorController> _logger;

        public VehiclePriceCalculatorController(IAPIService APIService, ILogger<VehiclePriceCalculatorController> logger)
        {
            _APIService = APIService ?? throw new ArgumentNullException(nameof(APIService));
            _logger = logger;
        }

        [HttpGet("vehicleTypes")]
        public async Task<IActionResult> GetAllVehicleTypes()
        {
            var vehicleTypeList = await _APIService.GetAllVehicleTypes();
            return Ok(vehicleTypeList);
        }

        [HttpGet("vehiclePriceTransaction")]
        public async Task<IActionResult> GetAllVehiclePriceTransactions()
        {
            var vehiclePriceTransactionList = await _APIService.GetAllVehiclePriceTransactions();
            return Ok(vehiclePriceTransactionList);
        }

        [HttpPost("addVehiclePriceTransaction")]
        public async Task<IActionResult> AddVehiclePriceTransactions([FromBody] decimal basePrice, string vehicleType)
        {
            var vehicleTypeList = await _APIService.AddVehiclePriceTransactions(basePrice,vehicleType);
            return Ok(vehicleTypeList);
        }
    }
}
