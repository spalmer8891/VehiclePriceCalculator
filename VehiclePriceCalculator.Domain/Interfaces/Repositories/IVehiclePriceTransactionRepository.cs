using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Domain.Interfaces.Repositories
{
    public interface IVehiclePriceTransactionRepository
    {
        Task<IEnumerable<VehiclePriceTransaction>> GetVehiclePriceTransactionListAsync();

        Task<VehiclePriceTransaction> AddVehiclePriceTransactionListAsync(VehiclePriceTransaction vehiclePriceTransaction);
    }
}
