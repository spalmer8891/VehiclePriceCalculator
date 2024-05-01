import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { VehiclePriceTransaction } from '../model/vehicle-price-transaction.model';
import { VehicleTypeService } from '../service/vehicle-type.service';
import { VehicleTypeEnum } from '../enum/vehicle-type.enum';
import { VehicleCalculate } from '../model/vehicle-calculate.model';

@Injectable({
  providedIn: 'root'
})
export class VehiclePriceTransactionService {

  public vehiclePriceTransaction: VehiclePriceTransaction = new VehiclePriceTransaction();
  public vehiclePriceTransactionList: VehiclePriceTransaction[] = [];
  private readonly baseUrl: string = 'https://localhost:7148/api/VehiclePriceCalculator'

  constructor(private http: HttpClient,private vehicleTypeService: VehicleTypeService) { }

  get(): Observable<VehiclePriceTransaction[]> {
    return this.http.get<VehiclePriceTransaction[]>(`${this.baseUrl}/vehiclePriceTransaction`);
  }


  post(basePrice: number, vehicleType: number): Observable<any> {
    const url = `${this.baseUrl}/addVehiclePriceTransaction`;
    const vehicleCalculate: VehicleCalculate = {
      basePrice: basePrice,
      vehicleType: vehicleType
      };

    return this.http.post<VehiclePriceTransaction>(url, vehicleCalculate).pipe(
      tap(() => this.vehicleTypeService.get()));
  }

  put(vehiclePriceTransaction: VehiclePriceTransaction): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${vehiclePriceTransaction.id}`, vehiclePriceTransaction).pipe(
      tap(() => this.get())
    );
  }

  delete(vehiclePriceTransactionId: number | string): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}?id=${vehiclePriceTransactionId}`).pipe(
      tap(() => this.get())
    );
  }
}
