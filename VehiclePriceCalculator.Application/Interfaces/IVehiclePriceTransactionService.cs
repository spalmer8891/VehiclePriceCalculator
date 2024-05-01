using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Application.Models;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Enum;
using VehiclePriceCalculator.Domain.Model;

namespace VehiclePriceCalculator.Application.Interfaces
{
    public interface IVehiclePriceTransactionService
    {
        Task<IEnumerable<VehiclePriceTransactionModel>> GetVehiclePriceTransactionList();
        Task<VehiclePriceTransactionModel> AddVehiclePriceTransactionList(VehiclePriceTransaction vehiclePriceTransaction);
        Task<VehiclePriceTransactionModel> CalculateVehiclePrice(VehicleCalculateModel model);
    }
}
