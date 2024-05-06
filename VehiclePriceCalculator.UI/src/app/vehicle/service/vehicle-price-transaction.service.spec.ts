import { TestBed } from '@angular/core/testing';

import { VehiclePriceTransactionService } from './vehicle-price-transaction.service';

describe('VehiclePriceTransactionService', () => {
  let service: VehiclePriceTransactionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehiclePriceTransactionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
