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
        public decimal CalculateBasicFee(decimal basePrice, Enum.VehicleType vehicleType);
        public decimal CalculateSpecialFee(decimal basePrice, Enum.VehicleType vehicleType);
        public decimal CalculateAssociationFee(decimal basePrice);
        public VehiclePriceTransaction CalculateTotalCost(VehicleCalculateModel model);
    }
}
