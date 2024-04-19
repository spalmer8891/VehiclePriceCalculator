using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Enum;
using VehiclePriceCalculator.Domain.Model;

namespace VehiclePriceCalculator.Domain.Interfaces
{
    public interface IVehiclePriceCalculate
    {
        public VehiclePriceTransaction CalculateTotalCost(Vehicle vehicle, Enum.VehicleType vehicleType);
    }
}
