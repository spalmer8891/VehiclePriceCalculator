using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePriceCalculator.Domain.Entities
{
    public class VehicleType : Entity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string VehicleTypeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }  
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public virtual VehiclePriceTransaction VehicleTransaction { get; set; }

        //public VehicleType( VehiclePriceTransaction vehiclePriceTransaction)
        //{
        //    VehicleTransaction = vehiclePriceTransaction;
        //}
    }
}
