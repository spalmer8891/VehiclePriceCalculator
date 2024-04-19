using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;

namespace VehiclePriceCalculator.Application.CQRS.Commands
{
    public class AddVehiclePriceTransactionCommand : IRequest<VehiclePriceTransaction>
    {
        public int Id { get; set; }
        public decimal VehiclePrice { get; set; }
        public decimal BasicFee { get; set; }
        public decimal SpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }
        public decimal TotalCost { get; set; }
        public int VehicleTypeId { get; set; }

    }
}
