import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { VehicleInfoComponent } from './vehicle/vehicle-info/vehicle-info.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,VehicleInfoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'VehiclePriceCalculator.UI';
}
