using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePriceCalculator.Domain.Entities
{
    public class VehiclePriceTransaction : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? VehiclePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SpecialFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? AssociationFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? StorageFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCost { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }
        [DataType(DataType.Date)]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }     
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public virtual VehicleType VehicleType { get; set; }

    }
}
