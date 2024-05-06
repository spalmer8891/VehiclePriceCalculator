import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { VehicleTypeService } from '../service/vehicle-type.service'; 
import { VehicleType } from '../model/vehicle-type.model';
import { VehiclePriceTransactionService } from '../service/vehicle-price-transaction.service';
import { VehiclePriceTransaction } from '../model/vehicle-price-transaction.model';
import { VehiclePriceTransactionDTO } from '../model/vehicle-price-transaction.dto';
import { VehicleTypeEnum } from '../enum/vehicle-type.enum';

@Component({
  selector: 'app-vehicle-type',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './vehicle-info.component.html',
  styleUrl: './vehicle-info.component.css'
})
export class VehicleInfoComponent implements OnInit{

  vehicleTypeList: VehicleType[] = [];
  vehiclePriceTransactionList: VehiclePriceTransaction [] = [];
  vehiclePriceTransactionDTO: VehiclePriceTransactionDTO [] = [];
  basePrice: string='';
  vehicleType: string='';

  constructor(public vehicleTypeService: VehicleTypeService, public vehiclePriceTransactionService: VehiclePriceTransactionService) {}

  ngOnInit(): void {
   this.getVehicleTypes();
   this.getAllVehicleTransactions();
  }


 getAllVehicleTransactions():void{
    this.vehiclePriceTransactionService.get()
        .subscribe({
                next:(vehiclePriceTransactions: VehiclePriceTransaction[]) =>{
                  console.log('Data retrieved:', vehiclePriceTransactions);

                  this.vehiclePriceTransactionDTO = vehiclePriceTransactions.map(x => {
                    // Convert VehicleTypeId to respective enum text value
                    const vehicleTypeName = x.id === VehicleTypeEnum.Common ? 'Common' :
                                            x.id === VehicleTypeEnum.Luxury ? 'Luxury' :
                                            '';
                    return { ...x, vehicleTypeName }; // Add vehicleTypeName property to each VehiclePriceTransaction object
                });
                }
        })
 }

  getVehicleTypes(): void {
    this.vehicleTypeService.get()
      .subscribe({
        next: (vehicleTypes: VehicleType[]) => {
          console.log('Data retrieved:', vehicleTypes);
          this.vehicleTypeList = vehicleTypes;
        },
        error: (error) => {
          //console.error('Error fetching vehicle types:', error);
        }
      });
  }

  submitForm(form: NgForm) {
    if (form.valid) {
      const basePrice: string = form.value.basePrice;
      const vehicleTypeString: string = form.value.vehicleType;

      const vehicleType: VehicleTypeEnum = VehicleTypeEnum[vehicleTypeString as keyof typeof VehicleTypeEnum]; // Convert string to enum
      this.vehiclePriceTransactionService.post(parseInt(basePrice), parseInt(vehicleTypeString)).subscribe({
        next: () => {
          // Success handling
          console.log('Data posted successfully');
        },
        error: (error) => {
          // Error handling
          console.error('Error posting data:', error);
        }
      });
    }
  }

  resetForm(form: NgForm) {
    form.resetForm(); // Reset the form
  }
  

  

}
