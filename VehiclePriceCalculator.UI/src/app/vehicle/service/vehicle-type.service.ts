import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { VehicleType } from '../model/vehicle-type.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {

  private readonly baseUrl: string = 'https://localhost:7148/api/VehiclePriceCalculator/vehicletypes'

  constructor(private http: HttpClient) { }

  get(): Observable<VehicleType[]> {
    var data = this.http.get<VehicleType[]>(this.baseUrl, { headers: { Accept: 'application/json' } });
    return data;
  }

}
