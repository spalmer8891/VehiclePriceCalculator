using VehiclePriceCalculator.API.Models;

namespace VehiclePriceCalculator.API.Interfaces
{
    public interface IAPIService
    {
        Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes();
        Task<IEnumerable<VehiclePriceTransactionViewModel>> GetAllVehiclePriceTransactions();
        Task<VehiclePriceTransactionViewModel> AddVehiclePriceTransactions(decimal basePrice, string vehicleType);
    }
}
