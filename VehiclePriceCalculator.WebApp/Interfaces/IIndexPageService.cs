using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Enum;
using VehiclePriceCalculator.WebApp.ViewModels;

namespace VehiclePriceCalculator.WebApp.Interfaces
{
    public interface IIndexPageService
    {
        Task<IEnumerable<VehicleTypeViewModel>> GetAllVehicleTypes();
        Task<IEnumerable<VehiclePriceTransactionViewModel>> GetAllVehiclePriceTransactions();
        Task<VehiclePriceTransactionViewModel> AddVehiclePriceTransactions(decimal basePrice, string vehicleType);
    }
}
