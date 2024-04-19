using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Enum;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Model;

namespace VehiclePriceCalculator.Domain.Services
{
    public class VehiclePriceCalculatorService : IVehiclePriceCalculate
    {
        public VehiclePriceCalculatorService() { }

        public decimal CalculateBasicFee(decimal basePrice, Enum.VehicleType vehicleType)
        {
            // Calculate basic fee as 10% of the price of the vehicle
            decimal basicFee = basePrice * 0.10m;

            // Adjust basic fee based on vehicle type
            if (vehicleType == Enum.VehicleType.Common)
            {
                // Clamp basic fee between minimum $10 and maximum $50
                basicFee = Math.Max(10, Math.Min(basicFee, 50));
            }
            else if (vehicleType == Enum.VehicleType.Luxury)
            {
                // Clamp basic fee between minimum $25 and maximum $200
                basicFee = Math.Max(25, Math.Min(basicFee, 200));
            }
            return basicFee;
        }


        public decimal CalculateSpecialFee(decimal basePrice, Enum.VehicleType vehicleType)
        {
            decimal specialFeeRate = (vehicleType == Enum.VehicleType.Common) ? 0.02m : 0.04m;
            return basePrice * specialFeeRate;
        }

        public decimal CalculateAssociationFee(decimal basePrice)
        {
            switch (basePrice)
            {
                case var _ when basePrice <= 500:
                    return 5;
                case var _ when basePrice <= 1000:
                    return 10;
                case var _ when basePrice <= 3000:
                    return 15;
                default:
                    return 20;
            }
            //if (basePrice <= 500)
            //    return 5;
            //else if (basePrice <= 1000)
            //    return 10;
            //else if (basePrice <= 3000)
            //    return 15;
            //else
            //    return 20;
        }

        public VehiclePriceTransaction CalculateTotalCost(Vehicle vehicle, Enum.VehicleType vehicleType)
        {
            decimal basicFee = CalculateBasicFee(vehicle.BasePrice, vehicleType);
            decimal specialFee = CalculateSpecialFee(vehicle.BasePrice, vehicle.Type);
            decimal associationFee = CalculateAssociationFee(vehicle.BasePrice);
            decimal storageFee = vehicle.StorageFee; // Fixed storage fee

            return new VehiclePriceTransaction
            {
                VehicleTypeId = (int)vehicle.Type,
                VehiclePrice = vehicle.BasePrice,
                BasicFee = basicFee,
                SpecialFee = specialFee,
                AssociationFee = associationFee,
                StorageFee = storageFee,
                TotalCost = vehicle.BasePrice + basicFee + specialFee + associationFee + storageFee
            };
        }

    }
}
