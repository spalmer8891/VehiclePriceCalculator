import { TestBed } from '@angular/core/testing';

import { VehicleTypeService } from './vehicle-type.service';

describe('VehicleService', () => {
  let service: VehicleTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
