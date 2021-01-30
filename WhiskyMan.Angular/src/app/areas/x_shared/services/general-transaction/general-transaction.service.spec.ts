import { TestBed } from '@angular/core/testing';

import { GeneralTransactionService } from './general-transaction.service';

describe('GeneralTransactionService', () => {
  let service: GeneralTransactionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralTransactionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
