namespace VehiclePriceCalculator.WebApp.ViewModels
{
    public class VehiclePriceTransactionViewModel
    {
        public int Id { get; set; }
        public string VehicleTypeName { get; set; }
        public decimal VehiclePrice { get; set; }
        public decimal BasicFee { get; set; }
        public decimal SpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; }
        public decimal TotalCost { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
