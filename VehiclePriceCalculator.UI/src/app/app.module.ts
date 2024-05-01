import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { VehicleInfoComponent } from './vehicle/vehicle-info/vehicle-info.component';
import { VehiclePriceTransactionComponent } from './vehicle/vehicle-price-transaction/vehicle-price-transaction.component';
import { VehicleTypeService } from './vehicle/service/vehicle-type.service';

@NgModule({
  declarations: [
    //AppComponent,
    //VehicleTypeComponent,
    //VehiclePriceTransactionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    VehicleTypeService
  ],
  bootstrap:[]
  //bootstrap: [AppComponent]
})
export class AppModule { }
