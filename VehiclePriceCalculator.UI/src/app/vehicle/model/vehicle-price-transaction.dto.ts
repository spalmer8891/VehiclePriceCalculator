export interface VehiclePriceTransactionDTO {
    id:number;
    vehicleTypeName:string;
    vehiclePrice : number;
    basicFee : number;
    specialFee : number;
    associationFee : number;
    storageFee : number;
    totalCost : number;
}