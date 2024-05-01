using VehiclePriceCalculator.Domain.Model;
using VehiclePriceCalculator.Shared.Models;

namespace VehiclePriceCalculator.Shared.Interfaces
{
    public interface IPresentationService
    {
        Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes();
        Task<IEnumerable<VehiclePriceTransactionViewModel>> GetAllVehiclePriceTransactions();
        Task<VehiclePriceTransactionViewModel> AddVehiclePriceTransactions(VehicleCalculateModel vehicleCalculate);
    }
}
