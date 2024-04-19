using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePriceCalculator.Application.Models
{
    public class VehiclePriceTransactionModel
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
